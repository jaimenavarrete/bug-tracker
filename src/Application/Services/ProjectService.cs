﻿using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project>> GetProjects() => await _unitOfWork.ProjectRepository.GetAll();

        public async Task<Project?> GetProjectById(string id) => await _unitOfWork.ProjectRepository.GetById(id);

        public async Task InsertProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();
            project.AddCreationInfo(userId);

            await ValidateEntityValues(project);

            _unitOfWork.ProjectRepository.Insert(project);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProject(Project project)
        {
            var userId = Guid.NewGuid().ToString();

            var currentProject = await _unitOfWork.ProjectRepository.GetById(project.Id);

            if (currentProject is null)
                throw new EntityNotFoundException(nameof(Project), project.Id);

            await ValidateEntityValues(project);

            currentProject.Name = project.Name;
            currentProject.Description = project.Description;
            currentProject.TicketsPrefix = project.TicketsPrefix;
            currentProject.OwnerId = project.OwnerId;
            currentProject.StateId = project.StateId;
            currentProject.Tags = project.Tags;
            currentProject.StartDate = project.StartDate;
            currentProject.CompletionDate = project.CompletionDate;
            currentProject.GroupId = project.GroupId;
            currentProject.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProject(string id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id);

            if (project is null)
                throw new EntityNotFoundException(nameof(Project), id);

            _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(Project project)
        {
            await ValidateTicketsPrefix(project);
            await ValidateGroup(project);
            await ValidateProjectState(project);
            await ValidateProjectTags(project);
        }

        private async Task ValidateTicketsPrefix(Project project)
        {
            var existingProject =
                await _unitOfWork.ProjectRepository.GetByTicketsPrefix(project.TicketsPrefix);

            if (existingProject is not null &&
               existingProject.Id != project.Id &&
               existingProject.GroupId == project.GroupId
               )
                throw new DuplicateValueException(
                    "TicketsPrefix",
                    project.TicketsPrefix,
                    project.GroupId ?? "[Empty]"
                    );
        }

        private async Task ValidateGroup(Project project)
        {
            var group = await _unitOfWork.GroupRepository.GetById(project.GroupId ?? string.Empty);

            if (group is null && project.GroupId is not null)
                throw new EntityValueNotFoundException(nameof(Group), project.GroupId);
        }

        private async Task ValidateProjectState(Project project)
        {
            var state = await _unitOfWork.ProjectStateRepository.GetById(project.StateId);

            if (state is null)
                throw new EntityValueNotFoundException(nameof(ProjectState), project.StateId);

            if (state.GroupId != project.GroupId)
                throw new InvalidEntityValueException(nameof(ProjectState), state.Id, nameof(Project), nameof(Group));
        }

        private async Task ValidateProjectTags(Project project)
        {
            // The list is necessary to save the tags that are retrieved from database
            var tags = new List<ProjectTag>();

            foreach (var tag in project.Tags)
            {
                var projectTag = await _unitOfWork.ProjectTagRepository.GetById(tag.Id);

                if (projectTag is null)
                    throw new EntityValueNotFoundException(nameof(ProjectTag), tag.Id);

                if (projectTag.GroupId != project.GroupId)
                    throw new InvalidEntityValueException(nameof(ProjectTag), projectTag.Id, nameof(Project), nameof(Group));

                tags.Add(projectTag);
            }

            // Replace the list that has incomplete project tags to be able to save the project in database
            project.Tags = tags;
        }
    }
}

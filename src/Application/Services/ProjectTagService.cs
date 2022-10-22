using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class ProjectTagService : IProjectTagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectTag>> GetProjectTags() => await _unitOfWork.ProjectTagRepository.GetAll();

        public async Task<ProjectTag?> GetProjectTagById(string id) => await _unitOfWork.ProjectTagRepository.GetById(id);

        public async Task InsertProjectTag(ProjectTag projectTag)
        {
            var userId = Guid.NewGuid().ToString();
            projectTag.AddCreationInfo(userId);

            await ValidateEntityValues(projectTag);

            _unitOfWork.ProjectTagRepository.Insert(projectTag);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateProjectTag(ProjectTag projectTag)
        {
            var userId = Guid.NewGuid().ToString();

            var currentProjectTag = await _unitOfWork.ProjectTagRepository.GetById(projectTag.Id);

            if (currentProjectTag is null)
                throw new EntityNotFoundException(nameof(ProjectTag), projectTag.Id);

            await ValidateEntityValues(projectTag);

            currentProjectTag.Name = projectTag.Name;
            currentProjectTag.GroupId = projectTag.GroupId;
            currentProjectTag.ColorHexCode = projectTag.ColorHexCode;
            currentProjectTag.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteProjectTag(string id)
        {
            var projectTag = await _unitOfWork.ProjectTagRepository.GetProjectTagToDeleteById(id);

            if (projectTag is null)
                throw new EntityNotFoundException(nameof(ProjectTag), id);

            _unitOfWork.ProjectTagRepository.Delete(projectTag);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(ProjectTag projectTag)
        {
            var group = await _unitOfWork.GroupRepository.GetById(projectTag.GroupId ?? string.Empty);
            if (group is null && projectTag.GroupId is not null)
                throw new EntityValueNotFoundException(nameof(Group), projectTag.GroupId);
        }
    }
}

using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Group>> GetGroups() => await _unitOfWork.GroupRepository.GetAll();

        public async Task<Group?> GetGroupById(string id) => await _unitOfWork.GroupRepository.GetById(id);

        public async Task InsertGroup(Group group)
        {
            var userId = Guid.NewGuid().ToString();
            group.AddCreationInfo(userId);

            _unitOfWork.GroupRepository.Insert(group);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateGroup(Group group)
        {
            var userId = Guid.NewGuid().ToString();

            var currentGroup = await _unitOfWork.GroupRepository.GetById(group.Id);

            if (currentGroup is null)
                throw new EntityNotFoundException(nameof(Group), group.Id);

            currentGroup.Name = group.Name;
            currentGroup.Description = group.Description;
            currentGroup.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteGroup(string id)
        {
            var group = await _unitOfWork.GroupRepository.GetById(id);

            if (group is null)
                throw new EntityNotFoundException(nameof(Group), id);

            _unitOfWork.GroupRepository.Delete(group);
            await _unitOfWork.CompleteAsync();
        }
    }
}

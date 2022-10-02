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

        public async Task<Group?> InsertGroup(Group group)
        {
            var userId = Guid.NewGuid().ToString();
            group.AddCreationInfo(userId);

            _unitOfWork.GroupRepository.Insert(group);
            var result = await _unitOfWork.CompleteAsync();

            if(!result)
                throw new EntityNotFoundException("The group could not be created");

            return group;
        }

        public async Task<bool> UpdateGroup(Group group)
        {
            var userId = Guid.NewGuid().ToString();

            var currentGroup = await _unitOfWork.GroupRepository.GetById(group.Id);

            if (currentGroup is null)
                throw new EntityNotFoundException("The group you are modifying does not exist.");

            currentGroup.Name = group.Name;
            currentGroup.Description = group.Description;
            currentGroup.UpdateModificationInfo(userId);

            var result = await _unitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> DeleteGroup(string id)
        {
            var group = await _unitOfWork.GroupRepository.GetById(id);

            if (group is null)
                throw new EntityNotFoundException("The group you are deleting does not exist.");

            _unitOfWork.GroupRepository.Delete(group);
            var result = await _unitOfWork.CompleteAsync();

            return result;
        }
    }
}

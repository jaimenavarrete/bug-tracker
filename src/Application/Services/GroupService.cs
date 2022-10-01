using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

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
    }
}

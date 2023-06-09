using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project?> GetByTicketsPrefix(string ticketsPrefix);
    }
}
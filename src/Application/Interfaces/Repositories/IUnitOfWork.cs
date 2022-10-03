using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Group> GroupRepository { get; }

        IProjectRepository ProjectRepository { get; }

        ITicketRepository TicketRepository { get; }

        IBaseRepository<ProjectState> ProjectStateRepository { get; }

        IBaseRepository<TicketState> TicketStateRepository { get; }

        bool Complete();

        Task<bool> CompleteAsync();
    }
}

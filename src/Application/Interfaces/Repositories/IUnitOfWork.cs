using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Group> GroupRepository { get; }

        IProjectRepository ProjectRepository { get; }

        IBaseRepository<ProjectState> ProjectStateRepository { get; }

        IBaseRepository<ProjectTag> ProjectTagRepository { get; }

        ITicketRepository TicketRepository { get; }

        IBaseRepository<TicketState> TicketStateRepository { get; }

        IBaseRepository<TicketTag> TicketTagRepository { get; }

        bool Complete();

        Task<bool> CompleteAsync();
    }
}

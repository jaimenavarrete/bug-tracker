using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Group> GroupRepository { get; }

        IBaseRepository<Project> ProjectRepository { get; }

        IBaseRepository<ProjectState> ProjectStateRepository { get; }

        IProjectTagRepository ProjectTagRepository { get; }

        ITicketRepository TicketRepository { get; }

        IBaseRepository<TicketState> TicketStateRepository { get; }

        ITicketTagRepository TicketTagRepository { get; }

        bool Complete();

        Task<bool> CompleteAsync();
    }
}

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

        IBaseRepository<Ticket> TicketRepository { get; }

        IBaseRepository<TicketState> TicketStateRepository { get; }

        IBaseRepository<TicketTag> TicketTagRepository { get; }

        IUserRepository UserRepository { get; }

        ILookupBaseRepository<GravityLevel> GravityLevelRepository { get; }

        ILookupBaseRepository<Classification> ClassificationRepository { get; }

        ILookupBaseRepository<ReproducibilityLevel> ReproducibilityLevelRepository { get; }

        bool Complete();

        Task<bool> CompleteAsync();
    }
}

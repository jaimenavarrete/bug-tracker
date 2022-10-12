using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITicketTagService
    {
        Task<IEnumerable<TicketTag>> GetTicketTags();

        Task<TicketTag?> GetTicketTagById(string id);

        Task InsertTicketTag(TicketTag ticketTag);

        Task UpdateTicketTag(TicketTag ticketTag);

        Task DeleteTicketTag(string id);
    }
}

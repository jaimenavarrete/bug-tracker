using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    public class TicketTagService : ITicketTagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketTagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TicketTag>> GetTicketTags() => await _unitOfWork.TicketTagRepository.GetAll();

        public async Task<TicketTag?> GetTicketTagById(string id) => await _unitOfWork.TicketTagRepository.GetById(id);

        public async Task InsertTicketTag(TicketTag ticketTag)
        {
            var userId = Guid.NewGuid().ToString();
            ticketTag.AddCreationInfo(userId);

            await ValidateEntityValues(ticketTag);

            _unitOfWork.TicketTagRepository.Insert(ticketTag);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateTicketTag(TicketTag ticketTag)
        {
            var userId = Guid.NewGuid().ToString();

            var currentTicketTag = await _unitOfWork.TicketTagRepository.GetById(ticketTag.Id);

            if (currentTicketTag is null)
                throw new EntityNotFoundException(nameof(TicketTag), ticketTag.Id);

            await ValidateEntityValues(ticketTag);

            currentTicketTag.Name = ticketTag.Name;
            currentTicketTag.ProjectId = ticketTag.ProjectId;
            currentTicketTag.ColorHexCode = ticketTag.ColorHexCode;
            currentTicketTag.UpdateModificationInfo(userId);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteTicketTag(string id)
        {
            var ticketTag = await _unitOfWork.TicketTagRepository.GetTicketTagToDeleteById(id);

            if (ticketTag is null)
                throw new EntityNotFoundException(nameof(TicketTag), id);

            _unitOfWork.TicketTagRepository.Delete(ticketTag);
            await _unitOfWork.CompleteAsync();
        }

        private async Task ValidateEntityValues(TicketTag ticketTag)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(ticketTag.ProjectId ?? string.Empty);
            if (project is null && ticketTag.ProjectId is not null)
                throw new EntityValueNotFoundException(nameof(Project), ticketTag.ProjectId);
        }
    }
}

﻿using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ITicketStateService
    {
        Task<IEnumerable<TicketState>> GetTicketStates();

        Task<TicketState?> GetTicketStateById(string id);
    }
}
﻿using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Project> ProjectRepository { get; }

        bool Complete();

        Task<bool> CompleteAsync();
    }
}

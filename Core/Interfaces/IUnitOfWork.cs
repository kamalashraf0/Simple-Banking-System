﻿namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IAccountRepository AccountsRepository { get; }
        Task<int> SaveChangesAsync();

    }
}

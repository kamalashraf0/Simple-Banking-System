using Core.Interfaces;
using Infrastructure.ApplicationDbContext;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankDbCotext context;
        private Hashtable _repositories;
        private IAccountRepository _repository;


        public UnitOfWork(BankDbCotext _context)
        {
            context = _context;
        }
        public IAccountRepository AccountsRepository =>
            _repository ??= new AccountRepository(context);

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);

                _repositories.Add(type, repositoryInstance);

            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
        public void Dispose() => context.Dispose();

    }
}

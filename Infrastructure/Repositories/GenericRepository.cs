using Core.Interfaces;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BankDbCotext context;

        public GenericRepository(BankDbCotext _context)
        {
            context = _context;
        }
        public async Task AddAsync(T entity) => await context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);

        public void Update(T entity) => context.Set<T>().Update(entity);

    }
}

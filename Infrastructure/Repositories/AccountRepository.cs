using Core.Entities;
using Core.Interfaces;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly BankDbCotext context;

        public AccountRepository(BankDbCotext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<IReadOnlyList<Account>> GetAccountsbyCustomerIdAsync(int customerId) =>
            await context.Set<Account>().Where(x => x.CustomerId == customerId).ToListAsync();

    }
}

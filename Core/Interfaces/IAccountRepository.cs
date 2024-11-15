using Core.Entities;

namespace Core.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<IReadOnlyList<Account>> GetAccountsbyCustomerIdAsync(int id);

    }
}

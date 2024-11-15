using Core.DTOs;

namespace Application.Services.AccountService
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAccountsAsync();
        Task<AccountDto> GetAccountByIdAsync(int id);
        Task<IEnumerable<AccountDto>> GetAccountsByCustomerIdAsync(int id);
        Task DeleteAccountAsync(int id);

    }
}

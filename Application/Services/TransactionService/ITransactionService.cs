using Core.DTOs;

namespace Application.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();

        //Task<IEnumerable<TransactionDto>> GetTransactionsHistoryByAccountIdAsync(int accountId);
    }
}

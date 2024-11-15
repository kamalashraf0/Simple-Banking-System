using Application.Services.TransactionService;
using Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Simple_Banking_System.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService _transactionService)
        {
            transactionService = _transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAllTransactions()
        {


            var transactions = await transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }
    }
}

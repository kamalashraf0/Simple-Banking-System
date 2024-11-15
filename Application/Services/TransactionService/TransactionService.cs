using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services.TransactionService
{

    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public TransactionService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {

            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
        {
            var transactions = await unitOfWork.Repository<Transaction>().GetAllAsync();
            return mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }


    }
}

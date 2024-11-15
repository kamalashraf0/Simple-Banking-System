using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }





        public async Task DeleteAccountAsync(int id)
        {
            var account = await unitOfWork.Repository<Account>().GetByIdAsync(id);
            if (account != null)
            {
                unitOfWork.Repository<Account>().Delete(account);
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<AccountDto> GetAccountByIdAsync(int id)
        {
            var account = await unitOfWork.Repository<Account>().GetByIdAsync(id);
            return mapper.Map<AccountDto>(account);

        }

        public async Task<IEnumerable<AccountDto>> GetAccountsByCustomerIdAsync(int id)
        {
            var customerid = await unitOfWork.Repository<Customer>().GetByIdAsync(id);

            if (customerid == null)
                return null;

            var accountsofcustomer = await unitOfWork.AccountsRepository.GetAccountsbyCustomerIdAsync(id);
            return mapper.Map<IEnumerable<AccountDto>>(accountsofcustomer);
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountsAsync()
        {
            var accounts = await unitOfWork.Repository<Account>().GetAllAsync();
            return mapper.Map<IEnumerable<AccountDto>>(accounts);
        }


    }
}

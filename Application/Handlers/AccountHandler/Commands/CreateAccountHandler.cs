using AutoMapper;
using Core.Entities;
using Core.Features.Commands.AccountCommands;
using Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.AccountHandler.Commands
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<CreateAccountHandler> logger;
        private readonly IMapper mapper;

        public CreateAccountHandler(
            IUnitOfWork _unitOfWork,
            ILogger<CreateAccountHandler> _logger,
            IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            logger = _logger;
            mapper = _mapper;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

            var existingaccounts = await unitOfWork.AccountsRepository.GetAccountsbyCustomerIdAsync(request.CustomerId);

            if (existingaccounts.Count >= 2)
            {
                logger.LogInformation("Customer with ID {CustomerId} already has the maximum number of accounts", request.CustomerId);
                throw new InvalidOperationException("A customer can only have up to 2 accounts.");
            }

            if (existingaccounts.Any(act => act.AccountType == request.AccountType))
            {
                logger.LogInformation("Customer with ID {CustomerId} already has an account of type {AccountType}", request.CustomerId, request.AccountType);
                throw new InvalidOperationException("A customer cannot have more than one account of the same type.");
            }


            var account = mapper.Map<Account>(request);

            var accountcusid = await unitOfWork.Repository<Customer>().GetByIdAsync(request.CustomerId);


            if (accountcusid == null)
            {
                logger.LogInformation("The ID {AccountId} is not exists", request.CustomerId);
                throw new InvalidOperationException($"The ID {request.CustomerId} is not exists.");
            }


            await unitOfWork.Repository<Account>().AddAsync(account);
            await unitOfWork.SaveChangesAsync();

            logger.LogInformation("Account created successfully with ID {AccountId}", account.AccountId);

            return account.AccountId;


        }
    }
}

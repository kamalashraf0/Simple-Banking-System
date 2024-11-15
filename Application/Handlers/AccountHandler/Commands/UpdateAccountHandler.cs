using AutoMapper;
using Core.Entities;
using Core.Features.Commands.AccountCommands;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.AccountHandler.Commands
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public UpdateAccountHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }


        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await unitOfWork.AccountsRepository.GetByIdAsync(request.AccountId);

            if (account == null)
            {
                throw new InvalidOperationException($"The Id {request.AccountId} is not Exists");
            }

            var customerid = await unitOfWork.Repository<Customer>().GetByIdAsync(request.CustomerId);

            if (customerid == null)
            {
                throw new InvalidOperationException($"The Customer Id {request.CustomerId} does not exist");
            }


            mapper.Map(request, account);
            unitOfWork.AccountsRepository.Update(account);
            await unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

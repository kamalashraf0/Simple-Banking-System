using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Features.Queries.AccountQueries;
using Core.Interfaces;
using MediatR;

namespace Application.Handlers.AccountHandler.Queries
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAccountByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<AccountDto> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = await unitOfWork.Repository<Account>().GetByIdAsync(request.AccountId);
            return mapper.Map<AccountDto>(account);
        }
    }
}

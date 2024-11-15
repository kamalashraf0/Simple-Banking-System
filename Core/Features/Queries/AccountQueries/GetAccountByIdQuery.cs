using Core.DTOs;
using MediatR;

namespace Core.Features.Queries.AccountQueries
{
    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        public int AccountId { get; set; }

        public GetAccountByIdQuery(int accountId)
        {
            AccountId = accountId;
        }
    }
}

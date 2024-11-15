using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Features.Commands.AccountCommands;

namespace Application.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, AccountCreateDto>().ReverseMap();
            CreateMap<CreateAccountCommand, Account>();
            CreateMap<UpdateAccountCommand, Account>();

            CreateMap<Transaction, TransactionDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        }
    }
}

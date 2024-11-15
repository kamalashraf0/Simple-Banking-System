using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Features.Commands.AccountCommands
{
    public class UpdateAccountCommand : IRequest<bool>
    {

        public int AccountId { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public int CustomerId { get; set; }


    }
}

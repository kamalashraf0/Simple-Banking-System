using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Core.Features.Commands.AccountCommands
{
    public class CreateAccountCommand : IRequest<int>
    {
        [Required]
        public string AccountType { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? CustomerId { get; set; }

    }

    public class AccountCreateDto
    {
        [Required]
        public string AccountType { get; set; }
        [Required]
        public decimal Balance { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public int CustomerId { get; set; }
    }
}

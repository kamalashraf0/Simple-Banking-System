namespace Core.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string? AccountType { get; set; }

    public decimal? Balance { get; set; }

    public DateTime? DateOfCreation { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}

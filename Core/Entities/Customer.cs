namespace Core.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

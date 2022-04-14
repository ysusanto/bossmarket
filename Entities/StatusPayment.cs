namespace bossmarket.Entities;

public class StatusPayment
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Transaction> Transactions { get; set; }
}
namespace bossmarket.Entities;

public class Payment
{
    public int Id { get; set; }
    public string? CodePayment { get; set; }
    public string Name { get; set; }
    public string? PathImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Transaction> Transactions { get; set; }
}
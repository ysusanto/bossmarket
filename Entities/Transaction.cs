namespace bossmarket.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string? CodeTransaction { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Disc { get; set; }
    public decimal PPN { get; set; }
    public decimal GrandTotal { get; set; }

    public int Customers { get; set; }
    public List<TransactionDetail> TransactionDetails { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
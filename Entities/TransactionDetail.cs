namespace bossmarket.Entities;

public class TransactionDetail
{
    public int Id { get; set; }

   
    public decimal Price { get; set; }
    public string? LotCode { get; set; }
    public int Qty { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
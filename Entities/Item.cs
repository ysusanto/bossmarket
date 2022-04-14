namespace bossmarket.Entities;

public class Item
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? PathImage { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Weight { get; set; }
    public sbyte IsActive { get; set; }
    public List<TransactionDetail> TransactionDetails { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Item()
    {
        this.IsActive = 0;
    }

}
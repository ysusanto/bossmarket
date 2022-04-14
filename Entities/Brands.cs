namespace bossmarket.Entities;

public class Brands
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? PathImage { get; set; }
    public List<Item> Items { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
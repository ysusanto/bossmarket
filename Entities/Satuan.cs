namespace bossmarket.Entities;

public class Satuan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public List<Item> Items { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public Satuan()
    {
        this.Value = 0;
    }

}
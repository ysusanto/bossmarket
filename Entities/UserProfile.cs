namespace bossmarket.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Telp { get; set; }
    public string? Telp2 { get; set; }
    public string NIK { get; set; }
    public string? PlaceOfBirth { get; set; }
    public DateOnly? BirthDay { get; set; }
    public string? Address { get; set; }
    public Users Users { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}
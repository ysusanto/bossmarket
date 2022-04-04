using System.Text.Json.Serialization;
namespace bossmarket.Entities
{

    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
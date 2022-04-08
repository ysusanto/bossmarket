namespace bossmarket.Models.Users;

using System.Text.Json.Serialization;
using bossmarket.Entities;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string JwtToken { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }

    public AuthenticateResponse(Users user, string jwtToken, string refreshToken)
    {
        Id = user.Id;
        Role = user.Role;
        Email = user.Email;
        Username = user.Username;
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }
}
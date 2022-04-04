using System.ComponentModel.DataAnnotations;
using bossmarket.Entities;

namespace bossmarket.Models.Users
{
    public class CreateUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }
    }
}
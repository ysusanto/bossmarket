using System.ComponentModel.DataAnnotations;
using bossmarket.Entities;
namespace bossmarket.Models.Brand
{
    public class UpdateBrand
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
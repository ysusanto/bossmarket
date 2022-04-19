using System.ComponentModel.DataAnnotations;
using bossmarket.Entities;
namespace bossmarket.Models.Brand
{
    public class CreateBrand
    {
        [Required]
        public string Name { get; set; }
    }
}
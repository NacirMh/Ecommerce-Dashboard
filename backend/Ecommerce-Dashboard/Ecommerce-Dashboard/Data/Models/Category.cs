using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ecommerce_Dashboard.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; } // Assuming you store the image URL as a string

        public DateTime CreatedAt { get; set; } = DateTime.Now;

     

    }
}

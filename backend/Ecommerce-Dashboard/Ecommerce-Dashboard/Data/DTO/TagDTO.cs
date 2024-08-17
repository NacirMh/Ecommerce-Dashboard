using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Dashboard.Data.DTO
{
    public class TagDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }

    }
}

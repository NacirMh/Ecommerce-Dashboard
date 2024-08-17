using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Dashboard.Data.Models
{
    public class Billboard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; } // Assuming you store the image URL as a string

        [Required]
        public string Header { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.Now;

        public bool Status { get; set; } = false;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Dashboard.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Tag")]

        public int tagId { get; set; }

        public virtual Tag Tag
        {
            get; set;
        }

        public string Description { get; set; }

        public string Name { get; set; }

        public bool Featured { get; set; }

        public string Image { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }

        public string Discount { get; set; }

        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public DateTime FirstDate { get; set; } = DateTime.Now;

       
    }
}

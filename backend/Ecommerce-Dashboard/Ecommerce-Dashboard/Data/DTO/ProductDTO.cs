using Ecommerce_Dashboard.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_Dashboard.Data.DTO
{
    public class ProductDTO
    {
        public int CategoryId { get; set; }

        public int tagId { get; set; }

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

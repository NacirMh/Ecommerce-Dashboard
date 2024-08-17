using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ecommerce_Dashboard.Data.Models
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int AllQuantity { get; set; }

        // Navigation properties
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }


    }
}


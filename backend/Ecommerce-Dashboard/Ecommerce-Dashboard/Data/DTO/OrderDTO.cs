using Ecommerce_Dashboard.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Dashboard.Data.DTO
{
    public class OrderDTO
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string EmailTo { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public bool Status { get; set; }

        public ICollection<ProductOrderDTO> Products { get; set; } = new List<ProductOrderDTO>();
    }

    public class ProductOrderDTO
    {
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int AllQuantity { get; set; }

    }

}

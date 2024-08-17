using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ecommerce_Dashboard.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ProfileImage { get; set; } // Assuming you store the image URL as a string

        public string Bio { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public string country { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Order>? Orders { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public DateTimeOffset OrderDate { get; init; }
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        public Order(string address)
        {
            OrderDate = DateTimeOffset.UtcNow;
            Address = address;
        }
    }
}

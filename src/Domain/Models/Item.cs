using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Item
    {
        [Key]
        public Guid ItemId { get;}
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}

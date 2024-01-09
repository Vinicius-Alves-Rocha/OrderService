using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}

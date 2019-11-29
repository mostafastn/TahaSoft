using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Cart
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public Guid? CustomerID { get; set; }
    }
}

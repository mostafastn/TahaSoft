using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Product
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public Guid CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Discount { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.WebAPI.Models
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
        public DateTime SellStarDate { get; set; }

        [StringLength(50)]
        public string ShipingWeight { get; set; }

        public byte[] Photo { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }
    }
}
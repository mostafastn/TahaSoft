using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class CartItem
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid CartID { get; set; }
        [Required]
        public Guid ProductID { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public int Qty { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Receipt
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// count of items in an Receipt
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// an order may by have Customer or not
        /// it is free for simpel registration
        /// </summary>
        public Guid? UserID { get; set; }
    }
}

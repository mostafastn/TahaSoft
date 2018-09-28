using System;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.Domains
{
    public class LineItem : BaseEntity
    {
        [Required]
        public Guid OrderID { get; set; }
        [Required]
        public Guid ProductID { get; set; }
        [Required]
        public int OrderQty { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal UnitPriceDiscount { get; set; }

        public decimal LineTotal
        {
            get
            {
                return (this.UnitPrice - this.UnitPriceDiscount) * this.OrderQty;
            }
        }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}

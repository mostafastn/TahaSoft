using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
    public class LineItem : BaseEntity
    {
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public int OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        [Required]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

    }
}

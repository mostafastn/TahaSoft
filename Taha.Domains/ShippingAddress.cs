using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
    public class ShippingAddress : BaseEntity
    {
        [Required]
        public Customer CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Street1 { get; set; }

        [StringLength(50)]
        public string Street2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string PostalCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

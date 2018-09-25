using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
   public class Product : BaseEntity
    {
        
        
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

        public virtual Category Category { get; set; }
    }
}

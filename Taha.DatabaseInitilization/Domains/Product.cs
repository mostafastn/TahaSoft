using System;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
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

        public virtual tbl_Category Category { get; set; }
    }
}

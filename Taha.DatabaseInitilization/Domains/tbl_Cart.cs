using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Cart")]
    public class tbl_Cart : BaseEntity
    {
        [Required]
        public Guid fldProductID { get; set; }

        /// <summary>
        /// Product Price on create cart most save for next reports and changes
        /// </summary>
        [Required]
        public decimal fldPrice { get; set; }

        /// <summary>
        /// Product Discount on create cart most save for next reports and changes
        /// </summary>
        [Required]
        public decimal fldDiscount { get; set; }

        /// <summary>
        /// count items in an order
        /// </summary>
        public int fldQty { get; set; }

        /// <summary>
        /// an order may by have Customer or not
        /// it is free for simpel registration
        /// </summary>
        public Guid? fldCustomerID { get; set; }

        public virtual tbl_Product Product { get; }
        public virtual tbl_Customer Customer { get; }
        
        
    }
}

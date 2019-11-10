using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_CartItem")]
    public class tbl_CartItem : BaseEntity
    {

        [Required]
        public Guid fldCartID { get; set; }

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
        /// count of items in an order
        /// </summary>
        public int fldQty { get; set; }

        /// <summary>
        /// شرح کالا
        /// </summary>
        public string fldDescription  { get; set; }
        

        public virtual tbl_Cart Cart { get; set; }
        public virtual tbl_Product Product { get; set; }
    }
}

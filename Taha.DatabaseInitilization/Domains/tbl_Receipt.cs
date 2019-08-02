﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Warehouse.tbl_Receipt")]
    public class tbl_Receipt : BaseEntity
    {
        [Required]
        public Guid fldProductID { get; set; }
        
        [Required]
        public decimal fldPrice { get; set; }

        /// <summary>
        /// count of items in an Receipt
        /// </summary>
        public int fldQty { get; set; }

        /// <summary>
        /// an order may by have Customer or not
        /// it is free for simpel registration
        /// </summary>
        public Guid? fldUserID { get; set; }

        public virtual tbl_Product Product { get; }
        public virtual tbl_Customer Customer { get; }

        public virtual ICollection<tbl_ReceiptItem> ReceiptItem { get; set; }
        
    }
}

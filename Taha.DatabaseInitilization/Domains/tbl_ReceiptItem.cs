using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Warehouse.tbl_ReceiptItem")]
    public class tbl_ReceiptItem : BaseEntity
    {
        [Required]
        public Guid fldReceiptID { get; set; }

        [Required]
        public Guid fldProductID { get; set; }
        
        [Required]
        public decimal fldPrice { get; set; }

        /// <summary>
        /// count of items in a Record
        /// </summary>
        public int fldQty { get; set; }

        /// <summary>
        /// شرح کالا
        /// </summary>
        public string fldDescription { get; set; }
        /// <summary>
        /// ملاحضات
        /// </summary>
        public string fldConsiderations { get; set; }
        /// <summary>
        /// تایید شده
        /// </summary>
        public bool fldAccepted { get; set; }

        /// <summary>
        /// شماره رسید انبار
        /// </summary>
        public int fldWarehouseReceipNo { get; set; }

        public virtual tbl_Receipt Receipt { get; set; }
        public virtual tbl_Product Product { get; set; }
        
        
    }
}

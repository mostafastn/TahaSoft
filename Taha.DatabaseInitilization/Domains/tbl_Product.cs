using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Product")]
    public class tbl_Product : BaseEntity
    {
        public tbl_Product()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            DetailAssignment = new HashSet<tbl_DetailAssignment>();
            ImageAssignment = new HashSet<tbl_ImageAssignment>();

            CartItem = new HashSet<tbl_CartItem>();
            ReceiptItem = new HashSet<tbl_ReceiptItem>();
        }
        [Required]
        public Guid fldCategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string fldName { get; set; }

        [Required]
        public decimal fldPrice { get; set; }

        [Required]
        public decimal fldDiscount { get; set; }

        // ToDo :: add this entityes

        /// <summary>
        /// coding Visits most use
        /// </summary>
        //public int VisitsCount { get; set; }
        /// <summary>
        /// coding most use
        /// </summary>
        //public bool Available { get; set; }
        /// <summary>
        /// coding most use
        /// </summary>
        //public int AvailableCount { get; set; }

           
        /// <summary>
        /// each product was in one only one category and
        /// cannot have to or more category 
        /// </summary>
        public virtual tbl_Category Category { get; }

        /// <summary>
        /// each Product was in many cart
        /// </summary>
        public virtual ICollection<tbl_CartItem> CartItem { get; set; }

        /// <summary>
        /// each product was in many ReceiptItem
        /// </summary>
        public virtual ICollection<tbl_ReceiptItem> ReceiptItem { get; set; }

        public virtual ICollection<tbl_DetailAssignment> DetailAssignment { get; set; }
        public virtual ICollection<tbl_ImageAssignment> ImageAssignment { get; set; }
    }
}

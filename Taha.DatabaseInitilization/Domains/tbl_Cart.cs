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
        /// an order may by have Customer or not
        /// it is free for simpel registration
        /// </summary>
        public Guid? fldCustomerID { get; set; }

        /// <summary>
        /// شرح خرید
        /// </summary>
        public string fldDescription { get; set; }

        public virtual ICollection<tbl_CartItem> CartItem { get; }
        public virtual tbl_Customer Customer { get; }


    }
}

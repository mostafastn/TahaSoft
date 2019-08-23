using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_DetailAssignment")]
    public class tbl_DetailAssignment : BaseEntity
    {


        [Required]
        public Guid fldCodingID { get; set; }
        [Required]
        public Guid fldDetailID { get; set; }
        
        public virtual tbl_Detail Detail { get; }
       
        /// <summary>
        /// after delete Coding
        /// </summary>
        public virtual tbl_Store Store { get; }
        /// <summary>
        /// after delete Coding
        /// </summary>
        public virtual tbl_Product Product { get; }
    }
}

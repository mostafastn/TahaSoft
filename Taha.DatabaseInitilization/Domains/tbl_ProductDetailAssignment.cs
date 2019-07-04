using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_ProductDetailAssignment")]
    public class tbl_ProductDetailAssignment : BaseEntity
    {


        [Required]
        public Guid fldCodingID { get; set; }
        [Required]
        public Guid fldDetailID { get; set; }
        
        public virtual tbl_Detail Detail { get; }
        public virtual tbl_Coding Coding_X { get; }
    }
}

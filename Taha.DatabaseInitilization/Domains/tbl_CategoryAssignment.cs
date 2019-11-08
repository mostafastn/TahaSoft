using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_CategoryAssignment")]
    public class tbl_CategoryAssignment : BaseEntity
    {


        [Required]
        public Guid fldCodingID { get; set; }
        [Required]
        public Guid fldCategoryID { get; set; }

        public virtual tbl_Category Category { get; }
        
        //public virtual tbl_Store Store { get; }

        //public virtual tbl_Coding Coding { get; }
    }
}

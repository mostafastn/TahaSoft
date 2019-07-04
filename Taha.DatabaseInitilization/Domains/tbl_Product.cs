using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Product_X")]
    public class tbl_Product : BaseEntity
    {
        //[Required]
        //public Guid fldCategoryID { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string fldName { get; set; }

        //[Required]
        //public decimal fldPrice { get; set; }

        //[Required]
        //public decimal fldDiscount { get; set; }


        //public virtual tbl_Category Category { get; }
        public virtual tbl_Coding Coding { get; set; }
    }
}

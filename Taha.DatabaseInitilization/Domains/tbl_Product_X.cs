using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("dbo.tbl_Product_X")]
    public class tbl_Product_X : BaseEntity
    {
        public virtual tbl_Coding_X tbl_B { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("dbo.tbl_Coding_X")]
    public class tbl_Coding_X : BaseEntity
    {
        public virtual tbl_Product_X tbl_A { get; set; }
    }
}

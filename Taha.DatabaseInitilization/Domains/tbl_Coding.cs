using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Coding")]
    public class tbl_Coding : BaseEntity
    {
        public virtual tbl_Product Product { get; set; }
        public virtual ICollection<tbl_ProductDetailAssignment> ProductDetailAssignment { get; set; }
    }
}

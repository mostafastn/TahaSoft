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
        public virtual tbl_Store Store { get; set; }
        public virtual ICollection<tbl_DetailAssignment> DetailAssignment { get; set; }
        public virtual ICollection<tbl_ImageAssignment> ImageAssignment { get; set; }
        public virtual ICollection<tbl_CategoryAssignment> CategoryAssignment { get; set; }
    }
}

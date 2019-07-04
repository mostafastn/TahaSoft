using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Detail")]
    public class tbl_Detail : BaseEntity
    {

        public tbl_Detail()
        {
            tbl_ProductDetailAssignment = new HashSet<tbl_ProductDetailAssignment>();
        }

        [Required]
        public int fldPeriority { get; set; }
        [Required]
        public string fldCaption { get; set; }
        [Required]
        public string fldDescription { get; set; }

        public virtual ICollection<tbl_ProductDetailAssignment> tbl_ProductDetailAssignment { get; set; }
    }
}

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
            DetailAssignment = new HashSet<tbl_DetailAssignment>();
        }

        [Required]
        public int fldPeriority { get; set; }
        [Required]
        public string fldCaption { get; set; }
        [Required]
        public string fldDescription { get; set; }

        public virtual ICollection<tbl_DetailAssignment> DetailAssignment { get; set; }
    }
}

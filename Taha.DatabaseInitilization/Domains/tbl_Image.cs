using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Image")]
    public class tbl_Image : BaseEntity
    {

        public tbl_Image()
        {
            ImageAssignment = new HashSet<tbl_ImageAssignment>();
        }

        [Required]
        public int fldPeriority { get; set; }
        [Required]
        public string fldAlternativeText { get; set; }
        [Required]
        public string fldPath { get; set; }

        public virtual ICollection<tbl_ImageAssignment> ImageAssignment { get; set; }
    }
}

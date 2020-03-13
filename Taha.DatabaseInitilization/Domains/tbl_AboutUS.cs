using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_AboutUS")]
    public class tbl_AboutUS : BaseEntity
    {

        [Required]
        public int fldPeriority { get; set; }
        [Required]
        public string fldCaption { get; set; }
        [Required]
        public string fldDescription { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Common.tbl_User")]
    public class tbl_User : BaseEntity
    {
        public tbl_User()
        {

        }

        [Required]
        public Guid fldPersonID { get; set; }

        [Required]
        public string fldUserName { get; set; }

        [Required]
        public string fldPassword { get; set; }

        [Required]
        public bool fldActive { get; set; }

        public virtual tbl_Person Person { get; set; }


    }
}

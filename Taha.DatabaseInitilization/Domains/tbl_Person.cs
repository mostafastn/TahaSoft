using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Common.tbl_Person")]
    public class tbl_Person : BaseEntity
    {
        public tbl_Person()
        {
            User = new HashSet<tbl_User>();
        }

        [Required]
        public string fldFirstName { get; set; }
        
        [Required]
        public string fldLastName { get; set; }

        [Required]
        public string fldSSN { get; set; }

        [Required]
        public string fldPhone { get; set; }

        [Required]
        public string fldEmail { get; set; }

        [Required]
        public string fldAddress { get; set; }
        
        public virtual ICollection<tbl_User> User { get; set; }
        public virtual tbl_Customer Customer { get; set; }

    }
}

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
            //Cart = new HashSet<tbl_Cart>();
        }

        [Required]
        public string fldFirstName { get; set; }
        
        [Required]
        public string fldLastName { get; set; }

        [Required]
        public string SSN { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        //public virtual ICollection<tbl_Cart> Cart { get; set; }
        public virtual tbl_User User { get; set; }

    }
}

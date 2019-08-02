﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Customer")]
    public class tbl_Customer : BaseEntity
    {
        public tbl_Customer()
        {
            Cart = new HashSet<tbl_Cart>();
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
        
        public virtual ICollection<tbl_Cart> Cart { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public class tbl_CarouselSlide : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        public string fldAlternateText { get; set; }

        [Required]
        public string fldSourceAddress { get; set; }

        [Required]
        public bool fldActive { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_CarouselSlide")]
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

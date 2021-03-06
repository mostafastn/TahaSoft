﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_ImageAssignment")]
    public class tbl_ImageAssignment : BaseEntity
    {


        [Required]
        public Guid fldCodingID { get; set; }
        [Required]
        public Guid fldImageID { get; set; }

        public virtual tbl_Image Image { get; set; }

    }
}

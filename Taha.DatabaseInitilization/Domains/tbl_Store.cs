﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Store")]
    public class tbl_Store : BaseEntity
    {
        public tbl_Store()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
        }

        [Required]
        [MaxLength(50)]
        public string fldName { get; set; }

        [Required]
        public string fldIntroductionSummary { get; set; }

        [Required]
        public string fldLink { get; set; }
               
        /// <summary>
        /// coding Visits most use
        /// </summary>
        //public int VisitsCount { get; set; }
    }
}

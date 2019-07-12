using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Store")]
    public class tbl_Store : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string fldName { get; set; }

        [Required]
        public string fldIntroductionSummary { get; set; }

        [Required]
        public string Link { get; set; }
        

        /// <summary>
        /// ProductMenu && Image are in Coding with assignment
        /// </summary>
        public virtual tbl_Coding Coding { get; set; }


        /// <summary>
        /// coding Visits most use
        /// </summary>
        //public int VisitsCount { get; set; }
    }
}

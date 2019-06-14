using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public class tbl_Category : BaseEntity
    {
        #region Constructor
        public tbl_Category()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            ChilList = new HashSet<tbl_Category>();
        }

        #endregion


        [Required]
        [MaxLength(50)]
        public string fldName { get; set; }

        [Required]
        public int fldPeriority { get; set; }

        public Guid? fldParentID { get; set; }

        public virtual tbl_Category Parent { get; }
        public virtual ICollection<tbl_Category> ChilList { get; }

    }
}

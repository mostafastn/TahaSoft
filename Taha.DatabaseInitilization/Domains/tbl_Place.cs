using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public class c : BaseEntity
    {
        #region Constructor
        public tbl_Place()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            ChilList = new HashSet<tbl_Place>();
        }

        #endregion


        [Required]
        [MaxLength(50)]
        public string fldName { get; set; }

        [Required]
        public int fldPeriority { get; set; }

        public Guid? fldParentID { get; set; }

        public virtual tbl_Place Parent { get; }
        public virtual ICollection<tbl_Place> ChilList { get; }

    }
}

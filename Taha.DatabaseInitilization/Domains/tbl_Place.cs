using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Place")]
    public class tbl_Place : BaseEntity
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

        public virtual tbl_Place Parent { get; set; }
        public virtual ICollection<tbl_Place> ChilList { get; set; }

    }
}

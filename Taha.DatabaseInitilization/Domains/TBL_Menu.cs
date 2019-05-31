using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public class TBL_Menu : BaseEntity
    {
        #region Constructor
        public TBL_Menu()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            ChilList = new HashSet<TBL_Menu>();
        }
        
        #endregion


        [Required]
        [MaxLength(50)]
        public string FLDName { get; set; }
        
        public Guid? FLDParentID { get; set; }

        public virtual TBL_Menu Parent { get; }
        public virtual ICollection<TBL_Menu> ChilList { get;}
    }
}

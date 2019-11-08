using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Taha.Framework.Entity;
using Taha.Framework.Infrastructure;

namespace Taha.DatabaseInitilization.Domains
{
    [Table("Store.tbl_Coding")]
    public class tbl_Coding : BaseEntity
    {
        public tbl_Coding()
        {
            // this is necessary otherwise EF will throw null object reference error. you could also put ?? operator check for more interactive solution.  
            //DetailAssignment = new HashSet<tbl_DetailAssignment>();
            //ImageAssignment = new HashSet<tbl_ImageAssignment>();
            //CategoryAssignment = new HashSet<tbl_CategoryAssignment>();
        }

        public ObjectType fldObjectType { get; set; }

        //public virtual tbl_Category Category { get; set; }
        //public virtual tbl_Product Product { get; set; }
        //public virtual tbl_Store Store { get; set; }
        //public virtual ICollection<tbl_DetailAssignment> DetailAssignment { get; set; }
        //public virtual ICollection<tbl_ImageAssignment> ImageAssignment { get; set; }
        //public virtual ICollection<tbl_CategoryAssignment> CategoryAssignment { get; set; }
    }
}
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
      
        public ObjectType fldObjectType { get; set; }
        
    }
}
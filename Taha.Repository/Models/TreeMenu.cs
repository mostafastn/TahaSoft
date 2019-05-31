using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taha.Repository.Models
{
    public class TreeMenu
    {

        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public Guid? ParentID { get; set; }
    }
}
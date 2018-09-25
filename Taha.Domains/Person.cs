using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
    public class Person : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddres { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
    }
}

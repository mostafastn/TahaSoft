using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

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

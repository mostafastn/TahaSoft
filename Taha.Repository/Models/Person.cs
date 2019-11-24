using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Person
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string SSN { get; set; }

        [Required]
        [MaxLength(14)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}

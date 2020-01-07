using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class User
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public Guid PersonID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}

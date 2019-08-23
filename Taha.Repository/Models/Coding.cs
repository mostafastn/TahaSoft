using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Coding
    {
        [Required]
        public Guid ID { get; set; }
    }
}

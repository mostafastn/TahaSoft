using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class AboutUS
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public int Periority { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

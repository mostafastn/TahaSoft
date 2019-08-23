using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Image
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public int Periority { get; set; }
        [Required]
        public string AlternativeText { get; set; }
        [Required]
        public string Path { get; set; }
    }
}

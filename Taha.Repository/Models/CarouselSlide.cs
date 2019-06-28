using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class CarouselSlide
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string AlternateText { get; set; }
        [Required]
        public string SourceAddress { get; set; }

        public bool Active { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class Store
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string IntroductionSummary { get; set; }
        [Required]
        public string Link { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.WebAPI.Models
{
    public class Category
    {

        [Required]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Periority { get; set; }


    }
}

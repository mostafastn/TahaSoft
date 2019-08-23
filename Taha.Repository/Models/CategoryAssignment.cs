using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class CategoryAssignment
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid CodingID { get; set; }
        [Required]
        public Guid CategoryID { get; set; }
    }
}

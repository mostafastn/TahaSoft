using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class ImageAssignment
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid CodingID { get; set; }
        [Required]
        public Guid ImageID { get; set; }
    }
}

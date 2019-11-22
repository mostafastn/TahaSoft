using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class DetailAssignment
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid CodingID { get; set; }
        [Required]
        public Guid DetailID { get; set; }
    }
}

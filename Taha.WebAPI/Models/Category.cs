using System.ComponentModel.DataAnnotations;

namespace Taha.WebAPI.Models
{
    public class Category 
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]        
        public int Periority { get; set; }
        

    }
}

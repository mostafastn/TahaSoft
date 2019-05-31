using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]        
        public int Periority { get; set; }
        
        public virtual List<Product> Products { get; set; }

    }
}

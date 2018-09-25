using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
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

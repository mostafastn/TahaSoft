using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Framework.Infrastructure;

namespace Taha.Repository.Models
{
    public class Customer
    {
        [Required]
        public Guid ID { get; set; }
    }
}

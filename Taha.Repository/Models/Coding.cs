using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Framework.Infrastructure;

namespace Taha.Repository.Models
{
    public class Coding
    {
        [Required]
        public Guid ID { get; set; }

        public ObjectType ObjectType{ get; set; }
    }
}

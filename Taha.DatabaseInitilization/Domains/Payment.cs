using System;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.DatabaseInitilization.Domains
{
    public  class Payment : BaseEntity
    {
        [Required]
        public Guid OrderID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool Valid { get; set; }

        public virtual Order Order { get; set; }

    }
}

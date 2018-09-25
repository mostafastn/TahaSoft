using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
  public  class Payment : BaseEntity
    {
        public Guid OrderID { get; set; }
        public decimal Amount { get; set; }
        
        public virtual Order Order { get; set; }

    }
}

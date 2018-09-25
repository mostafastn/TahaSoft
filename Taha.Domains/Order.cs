using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taha.Core.Entity;

namespace Taha.Domains
{
   public class Order : BaseEntity
    {
        
        public bool OnlineOrder { get; set; }

        /// <summary>
        /// شماره فاکتور
        /// </summary>
        public string SalesOrderNumber { get; set; }
        public Guid CustomerID { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime? DueDate { get; set; }

        public virtual IList<LineItem> LineItems { get; set; }
        public virtual IList<Payment> Payment { get; set; }
    }
}

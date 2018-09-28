using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taha.Framework.Entity;

namespace Taha.Domains
{
    public class Order : BaseEntity
    {
        [Required]
        public bool OnlineOrder { get; set; }

        /// <summary>
        /// شماره فاکتور
        /// </summary>
        [Required]
        [StringLength(20)]
        public string SalesOrderNumber { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime? DueDate { get; set; }

        public virtual IList<LineItem> LineItems { get; set; }
        public virtual IList<Payment> Payment { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Repository.Models
{
    public class ReceiptItem
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public Guid ReceiptID { get; set; }

        [Required]
        public Guid ProductID { get; set; }

        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// count of items in a Record
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// شرح کالا
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// ملاحضات
        /// </summary>
        public string Considerations { get; set; }
        /// <summary>
        /// تایید شده
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// شماره رسید انبار
        /// </summary>
        public int WarehouseReceipNo { get; set; }
    }
}

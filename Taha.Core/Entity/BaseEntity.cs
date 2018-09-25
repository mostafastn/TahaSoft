using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taha.Core.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.ID = Guid.NewGuid();
            this.InsertDate = Infrastructure.Utility.Curent.Now();
        }



        /// <summary>
        /// کلید اصلی
        /// </summary>

        [Key]
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// زمان درج
        /// </summary>
        [Required]
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// زمان اصلاح
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// زمان حذف
        /// </summary>
        public DateTime? DeleteDate { get; set; }


        /// <summary>
        /// مشخص کننده اطلاعات اصلاح شده
        /// </summary>
        public bool IsUpdate
        {
            get
            {
                return this.UpdateDate != null;
            }
        }
        /// <summary>
        /// مشخص کننده اطلاعات حذف شده
        /// </summary>
        public bool IsDelete
        {
            get
            {
                return this.DeleteDate != null;
            }
        }
    }
}

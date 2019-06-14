using System;
using System.ComponentModel.DataAnnotations;

namespace Taha.Framework.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.fldID = Guid.NewGuid();
            this.fldInsertDate = Infrastructure.Utility.Curent.Now();
        }



        /// <summary>
        /// کلید اصلی
        /// </summary>

        [Key]
        [Required]
        public Guid fldID { get; set; }
        /// <summary>
        /// زمان درج
        /// </summary>
        [Required]
        public DateTime fldInsertDate { get; set; }

        /// <summary>
        /// زمان اصلاح
        /// </summary>
        public DateTime? fldUpdateDate { get; set; }

        /// <summary>
        /// زمان حذف
        /// </summary>
        public DateTime? fldDeleteDate { get; set; }


        /// <summary>
        /// مشخص کننده اطلاعات اصلاح شده
        /// </summary>
        public bool IsUpdate
        {
            get
            {
                return this.fldUpdateDate != null;
            }
        }
        /// <summary>
        /// مشخص کننده اطلاعات حذف شده
        /// </summary>
        public bool IsDelete
        {
            get
            {
                return this.fldDeleteDate != null;
            }
        }
    }
}

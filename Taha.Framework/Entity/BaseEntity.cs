using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taha.Framework.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.FLDID = Guid.NewGuid();
            this.FLDInsertDate = Infrastructure.Utility.Curent.Now();
        }



        /// <summary>
        /// کلید اصلی
        /// </summary>

        [Key]
        [Required]
        public Guid FLDID { get; set; }
        /// <summary>
        /// زمان درج
        /// </summary>
        [Required]
        public DateTime FLDInsertDate { get; set; }

        /// <summary>
        /// زمان اصلاح
        /// </summary>
        public DateTime? FLDUpdateDate { get; set; }

        /// <summary>
        /// زمان حذف
        /// </summary>
        public DateTime? FLDDeleteDate { get; set; }


        /// <summary>
        /// مشخص کننده اطلاعات اصلاح شده
        /// </summary>
        public bool IsUpdate
        {
            get
            {
                return this.FLDUpdateDate != null;
            }
        }
        /// <summary>
        /// مشخص کننده اطلاعات حذف شده
        /// </summary>
        public bool IsDelete
        {
            get
            {
                return this.FLDDeleteDate != null;
            }
        }
    }
}

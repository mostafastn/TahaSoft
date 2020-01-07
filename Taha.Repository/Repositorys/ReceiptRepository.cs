using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class ReceiptRepository : BaseRepository<TahaDatabaseContext, tbl_Receipt, Receipt>
    {
        public override IQueryable<tbl_Receipt> ToEntityQueryable(IQueryable<Receipt> values)
        {
            var tblMenus = values.Select(t => new tbl_Receipt()
            {
                fldID = t.ID,
                fldUserID= t.UserID,
                fldQty= t.Qty,
                fldPrice = t.Price,
            });

            return tblMenus;
        }

        public override IQueryable<Receipt> ToObjectQueryable(IQueryable<tbl_Receipt> values)
        {
            var menus = values.Select(t => new Receipt()
            {
                ID = t.fldID,
                UserID = t.fldUserID,
                Qty= t.fldQty,
                Price = t.fldPrice,
            });

            return menus;
        }
    }
}

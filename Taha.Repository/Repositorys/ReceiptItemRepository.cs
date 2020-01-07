using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class ReceiptItemRepository : BaseRepository<TahaDatabaseContext, tbl_ReceiptItem, ReceiptItem>
    {
        public override IQueryable<tbl_ReceiptItem> ToEntityQueryable(IQueryable<ReceiptItem> values)
        {
            var tblMenus = values.Select(t => new tbl_ReceiptItem()
            {
                fldID = t.ID,
                fldReceiptID= t.ReceiptID,
                fldProductID = t.ProductID,
                fldQty = t.Qty,
                fldPrice = t.Price,
                fldWarehouseReceipNo = t.WarehouseReceipNo,
                fldConsiderations = t.Considerations,
                fldDescription = t.Description,
                fldAccepted = t.Accepted,
            });

            return tblMenus;
        }

        public override IQueryable<ReceiptItem> ToObjectQueryable(IQueryable<tbl_ReceiptItem> values)
        {
            var menus = values.Select(t => new ReceiptItem()
            {
                ID = t.fldID,
                ReceiptID = t.fldReceiptID,
                ProductID = t.fldProductID,
                Qty = t.fldQty,
                Price = t.fldPrice,
                WarehouseReceipNo = t.fldWarehouseReceipNo,
                Considerations = t.fldConsiderations,
                Description = t.fldDescription,
                Accepted = t.fldAccepted,
            });

            return menus;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CartItemRepository : BaseRepository<TahaDatabaseContext, tbl_CartItem, CartItem>
    {
        public override IQueryable<tbl_CartItem> ToEntityQueryable(IQueryable<CartItem> values)
        {
            var tblMenus = values.Select(t => new tbl_CartItem()
            {
                fldID = t.ID,
                fldCartID = t.CartID,
                fldProductID = t.ProductID,
                fldDiscount = t.Discount,
                fldPrice = t.Price,
                fldQty = t.Qty,
                fldDescription = t.Description,
            });

            return tblMenus;
        }

        public override IQueryable<CartItem> ToObjectQueryable(IQueryable<tbl_CartItem> values)
        {
            var menus = values.Select(t => new CartItem()
            {
                ID = t.fldID,
                CartID = t.fldCartID,
                ProductID = t.fldProductID,
                Discount = t.fldDiscount,
                Price = t.fldPrice,
                Qty = t.fldQty,
                Description = t.fldDescription
            });

            return menus;
        }
    }
}

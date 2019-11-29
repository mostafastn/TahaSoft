using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CartRepository : BaseRepository<TahaDatabaseContext, tbl_Cart, Cart>
    {
        public override IQueryable<tbl_Cart> ToEntityQueryable(IQueryable<Cart> values)
        {
            var tblMenus = values.Select(t => new tbl_Cart()
            {
                fldID = t.ID,
                fldProductID = t.ProductID,
                fldCustomerID = t.CustomerID,
                fldDescription = t.Description
            });

            return tblMenus;
        }

        public override IQueryable<Cart> ToObjectQueryable(IQueryable<tbl_Cart> values)
        {
            var menus = values.Select(t => new Cart()
            {
                ID = t.fldID,
                ProductID = t.fldProductID,
                CustomerID = t.fldCustomerID,
                Description = t.fldDescription
            });

            return menus;
        }
    }
}

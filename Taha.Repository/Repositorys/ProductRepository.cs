using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class ProductRepository : BaseRepository<TahaDatabaseContext, tbl_Product, Product>
    {
        
        public override IQueryable<tbl_Product> ToEntityQueryable(IQueryable<Product> values)
        {
            var tblPerson = values.Select(t => new tbl_Product()
            {
                fldID = t.ID,
                fldCategoryID= t.CategoryID,
                fldName = t.Name,
                fldDiscount= t.Discount,
                fldPrice = t.Price,
            });

            return tblPerson;
        }

        public override IQueryable<Product> ToObjectQueryable(IQueryable<tbl_Product> values)
        {
            var persons = values.Select(t => new Product()
            {
                ID = t.fldID,
                CategoryID= t.fldCategoryID,
                Name = t.fldName,
                Price= t.fldPrice,
                Discount= t.fldDiscount,
            });

            return persons;
        }
    }
}

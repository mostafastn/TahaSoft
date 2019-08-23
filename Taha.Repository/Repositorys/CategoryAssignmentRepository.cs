using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CategoryAssignmentRepository : BaseRepository<TahaDatabaseContext, tbl_CategoryAssignment, CategoryAssignment>
    {
        public override IQueryable<tbl_CategoryAssignment> ToEntityQueryable(IQueryable<CategoryAssignment> values)
        {
            var tblMenus = values.Select(t => new tbl_CategoryAssignment()
            {
                fldID = t.ID,
                fldCodingID = t.CodingID,
                fldCategoryID = t.CategoryID,
            });

            return tblMenus;
        }

        public override IQueryable<CategoryAssignment> ToObjectQueryable(IQueryable<tbl_CategoryAssignment> values)
        {
            var menus = values.Select(t => new CategoryAssignment()
            {
                ID = t.fldID,
                CodingID = t.fldCodingID,
                CategoryID = t.fldCategoryID,
            });

            return menus;
        }
    }
}

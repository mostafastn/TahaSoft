using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class DetailAssignmentRepository : BaseRepository<TahaDatabaseContext, tbl_DetailAssignment, DetailAssignment>
    {
        public override IQueryable<tbl_DetailAssignment> ToEntityQueryable(IQueryable<DetailAssignment> values)
        {
            var tblMenus = values.Select(t => new tbl_DetailAssignment()
            {
                fldID = t.ID,
                fldCodingID = t.CodingID,
                fldDetailID = t.DetailID,
            });

            return tblMenus;
        }

        public override IQueryable<DetailAssignment> ToObjectQueryable(IQueryable<tbl_DetailAssignment> values)
        {
            var menus = values.Select(t => new DetailAssignment()
            {
                ID = t.fldID,
                CodingID = t.fldCodingID,
                DetailID = t.fldDetailID,
            });

            return menus;
        }
    }
}

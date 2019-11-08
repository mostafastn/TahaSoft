using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Infrastructure;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CodingRepository : BaseRepository<TahaDatabaseContext, tbl_Coding, Coding>
    {

        public override IQueryable<tbl_Coding> ToEntityQueryable(IQueryable<Coding> values)
        {
            var tblMenus = values.Select(t => new tbl_Coding()
            {
                fldID = t.ID,
                fldObjectType = t.ObjectType
            });

            return tblMenus;
        }

        public override IQueryable<Coding> ToObjectQueryable(IQueryable<tbl_Coding> values)
        {
            var menus = values.Select(t => new Coding()
            {
                ID = t.fldID,
                ObjectType = t.fldObjectType
            });

            return menus;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class PlaceRepository : BaseRepository<TahaDatabaseContext, tbl_Place, Place>
    {

        public RepositoryResult<IEnumerable<object>> complicateObjectTest()
        {
            var categories = curentContext.tbl_Place.Where(t => t.fldDeleteDate==null ).ToList();
            
            var b = from con in curentContext.tbl_Place
                    join conn in curentContext.tbl_Place on con.fldPeriority equals conn.fldPeriority
                where con.fldPeriority > 4
                select new
                {
                    con.fldName,
                    con.fldPeriority,
                    connName =conn.fldName,
                    connPeriority =conn.fldPeriority
                };

            return new RepositoryResult<IEnumerable<object>>()
            {
                Result = b,
                succeed = true,
                Message = ""
            };
        }

        public override IQueryable<tbl_Place> ToEntityQueryable(IQueryable<Place> values)
        {
            var tblMenus = values.Select(t => new tbl_Place()
            {
                fldID = t.ID,
                fldParentID = t.ParentID,
                fldName = t.Name,
                fldPeriority = t.Periority
            });

            return tblMenus;
        }

        public override IQueryable<Place> ToObjectQueryable(IQueryable<tbl_Place> values)
        {
            var menus = values.Select(t => new Place()
            {
                ID = t.fldID,
                ParentID = t.fldParentID,
                Name = t.fldName,
                Periority = t.fldPeriority
            });

            return menus;
        }
    }
}

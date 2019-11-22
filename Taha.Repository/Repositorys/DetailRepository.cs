using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class DetailRepository : BaseRepository<TahaDatabaseContext, tbl_Detail, Detail>
    {
        public override IQueryable<tbl_Detail> ToEntityQueryable(IQueryable<Detail> values)
        {
            var tblMenus = values.Select(t => new tbl_Detail()
            {
                fldID = t.ID,
                fldPeriority = t.Periority,
                fldCaption = t.Caption,
                fldDescription = t.Description
            });

            return tblMenus;
        }

        public override IQueryable<Detail> ToObjectQueryable(IQueryable<tbl_Detail> values)
        {
            var menus = values.Select(t => new Detail()
            {
                ID = t.fldID,
                Periority = t.fldPeriority,
                Caption = t.fldCaption,
                Description = t.fldDescription
            });

            return menus;
        }
    }
}

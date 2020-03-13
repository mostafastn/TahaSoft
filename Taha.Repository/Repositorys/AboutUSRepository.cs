using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class AboutUSRepository : BaseRepository<TahaDatabaseContext, tbl_AboutUS, AboutUS>
    {
        public override IQueryable<tbl_AboutUS> ToEntityQueryable(IQueryable<AboutUS> values)
        {
            var tblMenus = values.Select(t => new tbl_AboutUS()
            {
                fldID = t.ID,
                fldPeriority = t.Periority,
                fldCaption = t.Caption,
                fldDescription = t.Description
            });

            return tblMenus;
        }

        public override IQueryable<AboutUS> ToObjectQueryable(IQueryable<tbl_AboutUS> values)
        {
            var menus = values.Select(t => new AboutUS()
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

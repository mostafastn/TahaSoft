using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class ImageRepository : BaseRepository<TahaDatabaseContext, tbl_Image, Image>
    {
        public override IQueryable<tbl_Image> ToEntityQueryable(IQueryable<Image> values)
        {
            var tblMenus = values.Select(t => new tbl_Image()
            {
                fldID = t.ID,
                fldPath = t.Path,
                fldAlternativeText = t.AlternativeText,
                fldPeriority = t.Periority
            });

            return tblMenus;
        }

        public override IQueryable<Image> ToObjectQueryable(IQueryable<tbl_Image> values)
        {
            var menus = values.Select(t => new Image()
            {
                ID = t.fldID,
                Path = t.fldPath,
                AlternativeText = t.fldAlternativeText,
                Periority = t.fldPeriority
            });

            return menus;
        }
    }
}

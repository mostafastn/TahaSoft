using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class ImageAssignmentRepository : BaseRepository<TahaDatabaseContext, tbl_ImageAssignment, ImageAssignment>
    {
        public override IQueryable<tbl_ImageAssignment> ToEntityQueryable(IQueryable<ImageAssignment> values)
        {
            var tblMenus = values.Select(t => new tbl_ImageAssignment()
            {
                fldID = t.ID,
                fldCodingID = t.CodingID,
                fldImageID = t.ImageID,
            });

            return tblMenus;
        }

        public override IQueryable<ImageAssignment> ToObjectQueryable(IQueryable<tbl_ImageAssignment> values)
        {
            var menus = values.Select(t => new ImageAssignment()
            {
                ID = t.fldID,
                CodingID = t.fldCodingID,
                ImageID = t.fldImageID,
            });

            return menus;
        }
    }
}

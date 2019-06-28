using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class CarouselSlideRepository : BaseRepository<TahaDatabaseContext, tbl_CarouselSlide, CarouselSlide>
    {
        
        public override IQueryable<tbl_CarouselSlide> ToEntityQueryable(IQueryable<CarouselSlide> values)
        {
            var tblMenus = values.Select(t => new tbl_CarouselSlide()
            {
                fldID = t.ID,
                fldActive = t.Active,
                fldAlternateText= t.AlternateText,
                fldSourceAddress= t.SourceAddress
            });

            return tblMenus;
        }

        public override IQueryable<CarouselSlide> ToObjectQueryable(IQueryable<tbl_CarouselSlide> values)
        {
            var menus = values.Select(t => new CarouselSlide()
            {
                ID = t.fldID,
                Active = t.fldActive,
                AlternateText = t.fldAlternateText,
                SourceAddress = t.fldSourceAddress
            });

            return menus;
        }
    }
}

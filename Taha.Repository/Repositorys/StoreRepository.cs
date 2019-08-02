using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class StoreRepository : BaseRepository<TahaDatabaseContext, tbl_Store, Store>
    {
        
        public override IQueryable<tbl_Store> ToEntityQueryable(IQueryable<Store> values)
        {
            var tblMenus = values.Select(t => new tbl_Store()
            {
                fldID = t.ID,
                fldName= t.Name,
                fldIntroductionSummary= t.IntroductionSummary,
                fldLink= t.Link
            });

            return tblMenus;
        }

        public override IQueryable<Store> ToObjectQueryable(IQueryable<tbl_Store> values)
        {
            var menus = values.Select(t => new Store()
            {
                ID = t.fldID,
                Name = t.fldName,
                IntroductionSummary = t.fldIntroductionSummary,
                Link = t.fldLink
            });

            return menus;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;
using Taha.Repository.Models;

namespace Taha.Repository.Repositorys
{
    public class MenuRepository : BaseRepository<TahaDatabaseContext, TBL_Menu, TreeMenu>
    {
        
        public override IQueryable<TBL_Menu> ToEntityQueryable(IQueryable<TreeMenu> values)
        {
            var tblMenus = values.Select(t => new TBL_Menu()
            {
                fldID = t.ID,
                fldParentID = t.ParentID,
                fldName = t.Name
            });

            return tblMenus;
        }

        public override IQueryable<TreeMenu> ToObjectQueryable(IQueryable<TBL_Menu> values)
        {
            var menus = values.Select(t => new TreeMenu()
            {
                ID = t.fldID,
                ParentID = t.fldParentID,
                Name = t.fldName
            });

            return menus;
        }
    }
}

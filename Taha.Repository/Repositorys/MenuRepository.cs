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
        public override IEnumerable<TBL_Menu> ToEntity(IEnumerable<TreeMenu> value)
        {

            var tblMenus = value.Select(t => new TBL_Menu()
            {
                FLDID = t.ID,
                FLDParentID = t.ParentID,
                FLDName = t.Name
            }).ToList();

            return tblMenus;
        }
        public override IEnumerable<TreeMenu> ToObject(IEnumerable<TBL_Menu> value)
        {
            var menus = value.Select(t => new TreeMenu()
            {
                ID = t.FLDID,
                ParentID = t.FLDParentID,
                Name = t.FLDName
            }).ToList();

            return menus;
        }
        public override TBL_Menu ToEntity(TreeMenu value)
        {

            var tblMenu =  new TBL_Menu()
            {
                FLDID = value.ID,
                FLDParentID = value.ParentID,
                FLDName = value.Name
            };

            return tblMenu;
        }
        public override TreeMenu ToObject(TBL_Menu value)
        {
            var menu =  new TreeMenu()
            {
                ID = value.FLDID,
                ParentID = value.FLDParentID,
                Name = value.FLDName
            };

            return menu;
        }

        public override IQueryable<TBL_Menu> ToEntityQueryable(IQueryable<TreeMenu> values)
        {
            var tblMenus = values.Select(t => new TBL_Menu()
            {
                FLDID = t.ID,
                FLDParentID = t.ParentID,
                FLDName = t.Name
            });

            return tblMenus;
        }

        public override IQueryable<TreeMenu> ToObjectQueryable(IQueryable<TBL_Menu> values)
        {
            var menus = values.Select(t => new TreeMenu()
            {
                ID = t.FLDID,
                ParentID = t.FLDParentID,
                Name = t.FLDName
            });

            return menus;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.WebAPI;
using Taha.Repository.Repositorys;
using Taha.WebAPI.Models;

namespace Taha.WebAPI.Controllers
{
    public class MenuController : BaseController<MenuRepository, TBL_Menu, Menu>
    {
        public override List<TBL_Menu> CastToEntity(List<Menu> value)
        {

            var tblMenus =  value.Select(t=> new TBL_Menu()
            {
                FLDID = t.ID,
                FLDParentID = t.ParentID,
                FLDName = t.Name
            }).ToList();

           return tblMenus;
        }
    }
}

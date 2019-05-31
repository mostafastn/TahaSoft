using System;
using System.Collections.Generic;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.WebAPI;
using Taha.Repository;
using Taha.WebAPI.Models;
using Category = Taha.DatabaseInitilization.Domains.Category;

namespace Taha.WebAPI.Controllers
{
    public class CategoryBaseController : BaseController<CategoryRepository, Category, Models.Category>
    {
        public override List<DatabaseInitilization.Domains.Category> CastToEntity(List<Models.Category> value)
        {
            throw new NotImplementedException();
        }
    }


}
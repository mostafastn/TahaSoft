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
        public override IEnumerable<Category> ToEntity(IEnumerable<Models.Category> value)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Models.Category> ToObject(IEnumerable<Category> value)
        {
            throw new NotImplementedException();
        }
    }


}
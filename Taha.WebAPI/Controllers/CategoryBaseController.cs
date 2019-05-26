using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Entity;
using Taha.Framework.Repository;
using Taha.Framework.WebAPI;
using Taha.Repository;
using Taha.WebAPI.Controllers;

namespace Taha.WebAPI.Controllers
{
    public class CategoryBaseController : BaseController<CategoryRepository,Category>
    {

    }

  
}
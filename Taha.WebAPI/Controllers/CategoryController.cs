using Taha.Framework.WebAPI;
using Taha.Repository.Models;
using Taha.Repository.Repositorys;

namespace Taha.WebAPI.Controllers
{
    public class CategoryController : BaseController<CategoryRepository, Category>
    {
        //public override IHttpActionResult Delete(List<Guid> IDs)
        //{
        //    var a = new CategoryRepository();
        //    var result = a.Delete(IDs);
        //    if (result.succeed)
        //        return Ok(result.Result);
        //    else
        //        return BadRequest(result.Message);
        //}
    }
    
}

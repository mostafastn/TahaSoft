using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Entity;
using Taha.Framework.Repository;
using Taha.Repository;
using Taha.WebAPI.Controllers;

namespace Taha.WebAPI.Controllers
{
    public class catController : BaseController<CategoryRepository,Category>
    {

    }

    public class BaseController<TRepository, TEntity> : ApiController, IController
        where TRepository :IRepository<TEntity>, new()
        where TEntity : BaseEntity
    {
        public IHttpActionResult GetAll()
        {
            var repository = new TRepository();
            var result = repository.GetAll();
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }
    }

    public interface IController//<T>
                                //where T : class
    {

        IHttpActionResult GetAll();
        //IHttpActionResult GetByID(Guid ID);
        //IHttpActionResult Insert(List<T> value);
        //IHttpActionResult Update(List<T> value);
        //IHttpActionResult Delete(List<Guid> ID);
        //IHttpActionResult Save();

    }
}
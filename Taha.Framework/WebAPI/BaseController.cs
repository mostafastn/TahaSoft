using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Taha.Framework.Entity;
using Taha.Framework.Repository;

namespace Taha.Framework.WebAPI
{
   
    public class BaseController<TRepository, TEntity> : ApiController, IController
        where TRepository : IRepository<TEntity>, new()
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
}

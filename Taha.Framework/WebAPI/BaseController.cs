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
        private TRepository _Repository;
        public BaseController()
        {
            _Repository = new TRepository();
        }
        public IHttpActionResult GetAll()
        {
            var result = _Repository.GetAll();
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult GetByID(Guid ID)
        {
            var result = _Repository.GetByID(ID);
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }
    }
}

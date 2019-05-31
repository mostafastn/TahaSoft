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

    public abstract class BaseController<TRepository, TEntity, TModel> : ApiController, IController<TModel>
        where TRepository : IRepository<TEntity>, new()
        where TEntity : BaseEntity
        where TModel : class
    {
        #region propertise

        private TRepository _Repository;
        
        #endregion

        #region Contructor
        
        public BaseController()
        {
            _Repository = new TRepository();
        }

        #endregion

        #region Abstract Methods

        public abstract List<TEntity> CastToEntity(List<TModel> value);

        #endregion

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

        public IHttpActionResult Insert(List<TModel> value)
        {

            if (value == null)
                return BadRequest("Value is null");

            var domainCategory = CastToEntity(value);

            var result = _Repository.Insert(domainCategory);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);


            throw new NotImplementedException();
        }
    }
}

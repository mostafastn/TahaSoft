using System;
using System.Collections.Generic;
using System.Web.Http;
using Taha.Framework.Repository;

namespace Taha.Framework.WebAPI
{
    /// <summary>
    /// BaseController
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class BaseController<TRepository, TModel> : ApiController, IController<TModel>
    where TRepository : IRepository<TModel>, new()
    where TModel : class
    {

        #region Properties

        private TRepository curentRepository;

        #endregion

        #region Constructor

        public BaseController()
        {
            curentRepository = new TRepository();
        }

        #endregion

        #region Impliment IController Methodes

        public virtual IHttpActionResult Delete(List<Guid> IDs)
        {
            var result = curentRepository.Delete(IDs);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public virtual IHttpActionResult GetAll()
        {
            var result = curentRepository.GetAll();
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public virtual IHttpActionResult GetByID(Guid ID)
        {
            var result = curentRepository.GetByID(ID);
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public virtual IHttpActionResult Insert(List<TModel> value)
        {
            var result = curentRepository.Insert(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public virtual IHttpActionResult Update(List<TModel> value)
        {
            var result = curentRepository.Update(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        #endregion

    }
}

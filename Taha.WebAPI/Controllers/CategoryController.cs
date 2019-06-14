using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Taha.Framework.WebAPI;
using Taha.Repository.Models;
using Taha.Repository.Repositorys;

namespace Taha.WebAPI.Controllers
{
    public class CategoryController : ApiController, IController<Category>
    {
        #region Properties

        private CategoryRepository categoryRepository;

        #endregion

        #region Constructor

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        #endregion

        #region Impliment IController Methodes

        public IHttpActionResult GetAll()
        {
            var result = categoryRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Name)));
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult GetByID(Guid ID)
        {
            var result = categoryRepository.GetByID(ID);
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult Insert(List<Category> value)
        {
            var result = categoryRepository.Insert(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Update(List<Category> value)
        {
            var result = categoryRepository.Update(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Delete(List<Guid> IDs)
        {
            var result = categoryRepository.Delete(IDs);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        #endregion
    }
}

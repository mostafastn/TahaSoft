using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Taha.Framework.WebAPI;
using Taha.Repository.Models;
using Taha.Repository.Repositorys;

namespace Taha.WebAPI.Controllers
{
    public class MenuController : ApiController, IController<TreeMenu>
    {
        #region Properties

        private MenuRepository menuRepository;

        #endregion

        #region Constructor

        public MenuController()
        {
            menuRepository = new MenuRepository();
        }

        #endregion

        #region Impliment IController Methodes

        public IHttpActionResult GetAll()
        {
            var result = menuRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Name)));
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult GetByID(Guid ID)
        {
            var result = menuRepository.GetByID(ID);
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult Insert(List<TreeMenu> value)
        {
            var result = menuRepository.Insert(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Update(List<TreeMenu> value)
        {
            var result = menuRepository.Update(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Delete(List<Guid> IDs)
        {
            var result = menuRepository.Delete(IDs);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        #endregion
    }



}

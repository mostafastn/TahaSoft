using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Http;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Entity;
using Taha.Framework.Repository;
using Taha.Framework.WebAPI;
using Taha.Repository.Models;
using Taha.Repository.Repositorys;
using Taha.WebAPI.Models;

namespace Taha.WebAPI.Controllers
{
    public class MenuController : ApiController, IController<TreeMenu>
    {
        public IHttpActionResult GetAll()
        {
            var menuRepository = new MenuRepository();
            var result = menuRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Name)));
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }

        public IHttpActionResult GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Insert(List<TreeMenu> value)
        {
            var repository = new MenuRepository();
            var result = repository.Insert(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Update(List<TreeMenu> value)
        {
            var repository = new MenuRepository();
            var result = repository.Update(value);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        public IHttpActionResult Delete(List<Guid> IDs)
        {
            var repository = new MenuRepository();
            var result = repository.Delete(IDs);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }
    }



}

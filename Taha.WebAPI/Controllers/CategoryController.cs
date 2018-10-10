using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Taha.Repository;
using Taha.WebAPI.Models;

namespace Taha.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);

            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            try
            {
                var categoryRepository = new CategoryRepository();
                var result = categoryRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
                if (result.succeed)
                    response = Request.CreateResponse(HttpStatusCode.OK, result.Result);
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, result.Message);

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed, ex.Message);

            }
            return response;

        }

        [HttpGet]
        public IHttpActionResult GetAllHttpActionResult()
        {
            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
                return Ok();
            else
                return NotFound();
        }
    }
}

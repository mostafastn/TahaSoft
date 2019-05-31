﻿using System;
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
        public HttpResponseMessage GetAllHttpResponseMessage()
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
        public IHttpActionResult GetAll()
        {
            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Periority)));
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }
        [HttpGet]
        public IHttpActionResult complicateObjectTest()
        {
            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.complicateObjectTest();
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }
        
        [HttpPost]
        public IHttpActionResult Insert(IEnumerable<Category> categories)
        {
            if (categories == null)
                return BadRequest("Value is null");

            var domainCategory = categories.Select(t => new Taha.DatabaseInitilization.Domains.Category
            {
                Name = t.Name,
                Periority = t.Periority
            }).ToList();

            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.Insert(domainCategory);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }
        
        [HttpPut]
        public IHttpActionResult Update(IEnumerable<Category> categories)
        {
            if (categories == null)
                return BadRequest("Value is null");

            var domainCategory = categories.Select(t => new Taha.DatabaseInitilization.Domains.Category
            {
                FLDID = t.ID,
                Name = t.Name,
                Periority = t.Periority
            }).ToList();

            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.Update(domainCategory);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }
        
        [HttpPut]
        public IHttpActionResult Delete(IEnumerable<Guid> categorieIDs)
        {
            if (categorieIDs == null)
                return BadRequest("Value is null");
            
            var categoryRepository = new CategoryRepository();
            var result = categoryRepository.Delete(categorieIDs.ToList());
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }
    }
}

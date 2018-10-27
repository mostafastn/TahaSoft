using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taha.Repository;
using Taha.WebAPI.Models;

namespace Taha.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var productRepository = new ProductRepository();
            var result = productRepository.GetAll(orderBy: (t => t.OrderBy(u => u.Price)));
            if (result.succeed)
                return Ok(result.Result);
            else
                return NotFound();
        }
        [HttpGet]

        [HttpPost]
        public IHttpActionResult Insert(IEnumerable<Product> products)
        {
            if (products == null)
                return BadRequest("Value is null");

            var domainProduct = products.Select(t => new Taha.DatabaseInitilization.Domains.Product
            {
                Name = t.Name,
                CategoryID = t.CategoryID,
                Price=t.Price,
                Photo = t.Photo,
                DiscontinuedDate = t.DiscontinuedDate,
                SellStarDate = t.SellStarDate,
                SellEndDate = t.SellEndDate,
                ShipingWeight = t.ShipingWeight,                
            }).ToList();

            var productRepository = new ProductRepository();
            var result = productRepository.Insert(domainProduct);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        public IHttpActionResult Update(IEnumerable<Product> products)
        {
            if (products == null)
                return BadRequest("Value is null");

            var domainProduct = products.Select(t => new Taha.DatabaseInitilization.Domains.Product
            {
                ID = t.ID,
                Name = t.Name,
                CategoryID = t.CategoryID,
                Price = t.Price,
                Photo = t.Photo,
                DiscontinuedDate = t.DiscontinuedDate,
                SellStarDate = t.SellStarDate,
                SellEndDate = t.SellEndDate,
                ShipingWeight = t.ShipingWeight,
            }).ToList();

            var productRepository = new ProductRepository();
            var result = productRepository.Update(domainProduct);
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

        [HttpPut]
        public IHttpActionResult Delete(IEnumerable<Guid> productIDs)
        {
            if (productIDs == null)
                return BadRequest("Value is null");

            var productRepository = new ProductRepository();
            var result = productRepository.Delete(productIDs.ToList());
            if (result.succeed)
                return Ok(result.Result);
            else
                return BadRequest(result.Message);
        }

    }
}

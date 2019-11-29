using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using Taha.Repository.Models;


namespace Taha.WebAPI.Tests.APIControllerTest
{
    internal class ProductImplementaion
    {
        private static ProductController baseController;

        static ProductImplementaion()
        {
            //Arrange
            baseController = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var categoryResult = CategoryImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorieList = categoryResult.Content.ToList();

            var products = new List<Product>()
            {
                new Product() { ID = Guid.NewGuid(),CategoryID = categorieList[0].ID, Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = categorieList[0].ID, Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = categorieList[0].ID, Name= "Name A", Price= 10000 , Discount= 10},
            };

            var response = baseController.Insert(products);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var productResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var products = productResult.Content.ToList();

            products.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(products);
            return response;
        }
        internal static IHttpActionResult GetAll()
        {
            Insert();
            var response = baseController.GetAll();
            return response;
        }
        internal static IHttpActionResult GetByID()
        {
            var _products = GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var products = _products.Content.ToList();

            var response = baseController.GetByID(products[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _products = GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var productIDs = _products.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(productIDs);
            return response;
        }
    }

    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = ProductImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Product>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = ProductImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Product>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var productResult = ProductImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var productResult = ProductImplementaion.GetByID() as OkNegotiatedContentResult<Product>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = ProductImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

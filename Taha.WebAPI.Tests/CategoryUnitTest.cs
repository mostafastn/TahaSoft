using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Taha.DatabaseInitilization.Domains;

namespace Taha.WebAPI.Tests
{
    [TestClass]
    public class CategoryUnitTest
    {
        [TestMethod]
        public void TestGetAllHttpResponseMessage()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.GetAllHttpResponseMessage();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public void TestcatControllerGetAll()
        {
            // Arrange
            var controller = new CategoryBaseController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public void TestcatControllerGetByID()
        {
            // Arrange
            var controller = new CategoryBaseController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var id = Guid.Empty;
            Guid.TryParse("f7fdd643-9b4f-4723-acd4-e5af80a430e2", out id);
            
            // Act
            var response = controller.GetByID(id) as OkNegotiatedContentResult<Category>;

            // Assert
            Assert.IsNotNull(response);

        }
        [TestMethod]
        public void complicateObjectTest()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.complicateObjectTest() as OkNegotiatedContentResult<IEnumerable<object>>;

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var categories = new List<Models.Category>()
            {
                new Models.Category() {Name = "CategoryTest A",Periority = 1},
                new Models.Category() {Name = "CategoryTest B",Periority = 2},
                new Models.Category() {Name = "CategoryTest C",Periority = 3},
                new Models.Category() {Name = "CategoryTest D",Periority = 4},
            };
            
            var response = controller.Insert(categories) as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act

            var categoriesResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categories = categoriesResult.Content.ToList();

            var modelsCategories = (from t in categories
                                    select new Models.Category
                                    {
                                        ID = t.FLDID,
                                        Name = t.Name,
                                        Periority = t.Periority * 10
                                    }).ToList();

            var response = controller.Update(modelsCategories) as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(response);
        }


        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            var controller = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act

            var categoriesResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categories = categoriesResult.Content.ToList();
            var categoriesID = categories.Select(t => t.FLDID).ToList();

            var response = controller.Delete(categoriesID) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            // Assert
            Assert.IsNotNull(response);
        }
    }
}

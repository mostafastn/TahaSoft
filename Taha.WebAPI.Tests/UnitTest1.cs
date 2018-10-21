using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Taha.DatabaseInitilization.Domains;
using Taha.Framework.Repository;

namespace Taha.WebAPI.Tests
{
    [TestClass]
    public class UnitTest1
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
            var category = new Taha.WebAPI.Models.Category() { Name = "CategoryTest", Periority = 5 };
            var response = controller.Insert(category) as OkNegotiatedContentResult<IEnumerable<Category>>;

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
            var category = new Taha.WebAPI.Models.Category()
            {
                ID = Guid.Parse("1c7705f5-ef74-4522-85ae-2e28ac0f5bbc"),
                Name = "CategoryA",
                Periority = 5
            };
            var response = controller.Update(category) as OkNegotiatedContentResult<Category>;

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestUpdateAll()
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
                                        ID = t.ID,
                                        Name = t.Name,
                                        Periority = t.Periority * 10
                                    }).ToList();
            
            var response = controller.UpdateAll(modelsCategories) as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(response);
        }
    }
}

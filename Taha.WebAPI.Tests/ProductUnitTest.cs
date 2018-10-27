using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;
using System.Collections.Generic;
using Taha.DatabaseInitilization.Domains;
using System.Linq;
using Taha.Framework.Infrastructure;

namespace Taha.WebAPI.Tests
{
    [TestClass]
    public class ProductUnitTest
    {

        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            var controller = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;

            // Assert
            Assert.IsNotNull(response);

        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            var controller = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };


            var categoryController = new CategoryController
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

            categoryController.Insert(categories);

            var resCategory = categoryController.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var firstCategory = resCategory.Content.ToList().FirstOrDefault();

            var products = new List<Models.Product>()
            {
                new Models.Product() {
                    Name = "ProductTest A",
                    CategoryID = firstCategory.ID,
                    Price = 100,
                    Photo = null,
                    DiscontinuedDate = Utility.Curent.Now().AddYears(1),
                    SellStarDate = Utility.Curent.Now(),
                    SellEndDate = Utility.Curent.Now().AddMonths(11),
                    ShipingWeight = "100"
                },
                new Models.Product() {
                    Name = "ProductTest B",
                    CategoryID = firstCategory.ID,
                    Price = 200,
                    Photo = null,
                    DiscontinuedDate = Utility.Curent.Now().AddYears(1),
                    SellStarDate = Utility.Curent.Now(),
                    SellEndDate = Utility.Curent.Now().AddMonths(11),
                    ShipingWeight = "200"
                },
                new Models.Product() {
                    Name = "ProductTest C",
                    CategoryID = firstCategory.ID,
                    Price = 300,
                    Photo = null,
                    DiscontinuedDate = Utility.Curent.Now().AddYears(1),
                    SellStarDate = Utility.Curent.Now(),
                    SellEndDate = Utility.Curent.Now().AddMonths(11),
                    ShipingWeight = "300"
                },
                new Models.Product() {
                    Name = "ProductTest D",
                    CategoryID = firstCategory.ID,
                    Price = 400,
                    Photo = null,
                    DiscontinuedDate = Utility.Curent.Now().AddYears(1),
                    SellStarDate = Utility.Curent.Now(),
                    SellEndDate = Utility.Curent.Now().AddMonths(11),
                    ShipingWeight = "400"
                },
            };

            var response = controller.Insert(products) as OkNegotiatedContentResult<IEnumerable<Product>>;

            categoryController.Delete(resCategory.Content.ToList().Select(t=>t.ID));

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            var controller = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act

            var categoriesResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var categories = categoriesResult.Content.ToList();

            var modelsCategories = (from t in categories
                                    select new Models.Product
                                    {
                                        ID = t.ID,
                                        Name = t.Name,
                                        CategoryID = t.CategoryID,
                                        Price = t.Price * 10,
                                        Photo = t.Photo,
                                        DiscontinuedDate = t.DiscontinuedDate,
                                        SellStarDate = t.SellStarDate,
                                        SellEndDate = t.SellEndDate,
                                        ShipingWeight = t.ShipingWeight,
                                    }).ToList();

            var response = controller.Update(modelsCategories) as OkNegotiatedContentResult<IEnumerable<Product>>;

            // Assert
            Assert.IsNotNull(response);
        }
        
        [TestMethod]
        public void TestDelete()
        {
            // Arrange
            var controller = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act

            var categoriesResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var categories = categoriesResult.Content.ToList();
            var categoriesID = categories.Select(t => t.ID).ToList();

            var response = controller.Delete(categoriesID) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            // Assert
            Assert.IsNotNull(response);
        }
    }
}

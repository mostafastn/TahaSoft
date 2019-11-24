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
    [TestClass]
    public class ProductTest
    {
        private ProductController baseController;

        public ProductTest()
        {
            //Arrange
            baseController = new ProductController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void CRUDTest()
        {
            //Act
            var products = new List<Product>()
            {
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("86fd1246-059e-4398-b537-04341ec77a34"), Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("86fd1246-059e-4398-b537-04341ec77a34"), Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("86fd1246-059e-4398-b537-04341ec77a34"), Name= "Name A", Price= 10000 , Discount= 10},
            };

            var insertRresponse = baseController.Insert(products) as OkNegotiatedContentResult<IEnumerable<Product>>;
            var insertList = insertRresponse.Content.ToList();
            if (insertList == null)
                Assert.IsNotNull(insertList);

            insertList.ForEach(t => { t.Name = t.Name + " Updated "; });
            var updateResponse = baseController.Update(insertList) as OkNegotiatedContentResult<IEnumerable<Product>>;
            var updateList = updateResponse.Content.ToList();
            if (updateList == null)
                Assert.IsNotNull(updateList);

            var getAllResponse = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var getAllList = updateResponse.Content.ToList();
            if (getAllList == null)
                Assert.IsNotNull(getAllList);

            var getByIDResponse = baseController.GetByID(products[0].ID) as OkNegotiatedContentResult<Product>;
            var product = getByIDResponse.Content;
            if (product == null)
                Assert.IsNotNull(product);

            var productIDs = getAllList.Select(t => t.ID).ToList();

            var deleteResponse = baseController.Delete(productIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;
            var deleteList = deleteResponse.Content.ToList();

            Assert.IsNotNull(deleteList);

            //Assert

        }


        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var products = new List<Product>()
            {
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("daf2dafe-392d-4a85-bf05-6946b88f8262"), Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("daf2dafe-392d-4a85-bf05-6946b88f8262"), Name= "Name A", Price= 10000 , Discount= 10},
                new Product() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("daf2dafe-392d-4a85-bf05-6946b88f8262"), Name= "Name A", Price= 10000 , Discount= 10},
            };

            var response = baseController.Insert(products) as OkNegotiatedContentResult<IEnumerable<Product>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var productResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var products = productResult.Content.ToList();

            products.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(products) as OkNegotiatedContentResult<IEnumerable<Product>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var productResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;

            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _Products = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var products = _Products.Content.ToList();

            var productResult = baseController.GetByID(products[0].ID) as OkNegotiatedContentResult<Product>;

            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;

            var productIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(productIDs) as OkNegotiatedContentResult<IEnumerable<Product>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

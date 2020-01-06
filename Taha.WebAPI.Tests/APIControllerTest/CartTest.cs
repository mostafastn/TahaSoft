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

    internal class CartImplementaion
    {
        private static CartController baseController;

        static CartImplementaion()
        {
            //Arrange
            baseController = new CartController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var customerResult = CustomerImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            var customerList = customerResult.Content.ToList();

            var products = new List<Cart>()
            {
                new Cart() { ID = Guid.NewGuid(), Description= "Description A",CustomerID = customerList[0].ID,},
                new Cart() { ID = Guid.NewGuid(), Description= "Description B",CustomerID = customerList[0].ID,},
                new Cart() { ID = Guid.NewGuid(), Description= "Description C",CustomerID = customerList[0].ID,},
            };

            var response = baseController.Insert(products);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var cartResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            var carts = cartResult.Content.ToList();

            carts.ForEach(t => { t.Description = t.Description + " Updated "; });

            var response = baseController.Update(carts);
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
            var _carts = GetAll() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            var carts = _carts.Content.ToList();

            var response = baseController.GetByID(carts[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _carts = GetAll() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            var cartIDs = _carts.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(cartIDs);
            return response;
        }
    }

    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CartImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CartImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var productResult = CartImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var productResult = CartImplementaion.GetByID() as OkNegotiatedContentResult<Cart>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = CartImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }
    }
}

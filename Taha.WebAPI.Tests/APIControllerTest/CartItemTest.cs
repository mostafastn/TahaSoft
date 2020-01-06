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

    internal class CartItemImplementaion
    {
        private static CartItemController baseController;

        static CartItemImplementaion()
        {
            //Arrange
            baseController = new CartItemController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var cartResult = CartImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Cart>>;
            var cartList = cartResult.Content.ToList();

            var productResult = ProductImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var productList = productResult.Content.ToList();

            var cartItems = new List<CartItem>()
            {
                new CartItem() { ID = Guid.NewGuid(),CartID = cartList[0].ID, ProductID = productList[0].ID, Qty = 2, Price =1000, Discount = 100, Description= "Description A",},
                new CartItem() { ID = Guid.NewGuid(),CartID = cartList[0].ID, ProductID = productList[0].ID, Qty = 2, Price =1000, Discount = 100, Description= "Description B",},
                new CartItem() { ID = Guid.NewGuid(),CartID = cartList[0].ID, ProductID = productList[0].ID, Qty = 2, Price =1000, Discount = 100, Description= "Description C",},
            };

            var response = baseController.Insert(cartItems);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var cartItemResult = GetAll() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            var cartItems = cartItemResult.Content.ToList();

            cartItems.ForEach(t => { t.Description = t.Description + " Updated "; });

            var response = baseController.Update(cartItems);
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
            var _cartItems = GetAll() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            var cartItems = _cartItems.Content.ToList();

            var response = baseController.GetByID(cartItems[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _cartItems = GetAll() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            var cartItemIDs = _cartItems.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(cartItemIDs);
            return response;
        }
    }

    [TestClass]
    public class CartItemTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CartItemImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CartItemImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var productResult = CartItemImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<CartItem>>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var productResult = CartItemImplementaion.GetByID() as OkNegotiatedContentResult<CartItem>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = CartItemImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }
    }
}

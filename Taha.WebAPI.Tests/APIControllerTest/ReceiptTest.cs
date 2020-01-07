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

    internal class ReceiptImplementaion
    {
        private static ReceiptController baseController;

        static ReceiptImplementaion()
        {
            //Arrange
            baseController = new ReceiptController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var userResult = UserImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<User>>;
            var userList = userResult.Content.ToList();

            var products = new List<Receipt>()
            {
                new Receipt() { ID = Guid.NewGuid(), Qty = 5, Price = 1000 , UserID = userList[0].ID},
                new Receipt() { ID = Guid.NewGuid(), Qty = 5, Price = 1000 , UserID = userList[0].ID},
                new Receipt() { ID = Guid.NewGuid(), Qty = 5, Price = 1000 , UserID = userList[0].ID},
            };

            var response = baseController.Insert(products);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var receiptResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            var receipts = receiptResult.Content.ToList();

            receipts.ForEach(t => { t.Qty *= 2; });

            var response = baseController.Update(receipts);
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
            var _receipts = GetAll() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            var receipts = _receipts.Content.ToList();

            var response = baseController.GetByID(receipts[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _receipts = GetAll() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            var receiptIDs = _receipts.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(receiptIDs);
            return response;
        }
    }

    [TestClass]
    public class ReceiptTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = ReceiptImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = ReceiptImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var productResult = ReceiptImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var productResult = ReceiptImplementaion.GetByID() as OkNegotiatedContentResult<Receipt>;
            // Assert
            Assert.IsNotNull(productResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = ReceiptImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }
    }
}

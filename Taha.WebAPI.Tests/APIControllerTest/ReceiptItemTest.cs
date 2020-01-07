using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using Taha.Framework.Infrastructure;
using Taha.Repository.Models;


namespace Taha.WebAPI.Tests.APIControllerTest
{
    internal class ReceiptItemImplementaion
    {
        private static ReceiptItemController baseController;

        static ReceiptItemImplementaion()
        {
            //Arrange
            baseController = new ReceiptItemController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var receiptResult = ReceiptImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Receipt>>;
            var receiptList = receiptResult.Content.ToList();

            var productResult = ProductImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Product>>;
            var productList = productResult.Content.ToList();

            var receipts = productList.Select(t => new ReceiptItem()
            {
                ID = Guid.NewGuid(),
                ReceiptID = receiptList[0].ID,
                ProductID = t.ID,
                Qty = 10,
                Price = 1000,
                Description = "Description",
                Accepted = true,
                Considerations = "Considerations",
                WarehouseReceipNo = 123
            }).ToList();

            var response = baseController.Insert(receipts);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var receiptResult = GetAll() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            var receipts = receiptResult.Content.ToList();

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
            var _receipts = GetAll() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            var receipts = _receipts.Content.ToList();

            var response = baseController.GetByID(receipts[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _receipts = GetAll() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            var receiptIDs = _receipts.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(receiptIDs);
            return response;
        }
    }
    [TestClass]
    public class ReceiptItemTest
    {
       
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = ReceiptItemImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = ReceiptItemImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var response = ReceiptItemImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<ReceiptItem>>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var response = ReceiptItemImplementaion.GetByID() as OkNegotiatedContentResult<ReceiptItem>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var response = ReceiptItemImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(response);
        }

    }
}

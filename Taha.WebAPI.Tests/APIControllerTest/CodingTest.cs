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
    internal class CodingImplementaion
    {
        private static CodingController baseController;

        static CodingImplementaion()
        {
            //Arrange
            baseController = new CodingController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var storeResult = StoreImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var storeList = storeResult.Content.ToList();

            var codings = storeList.Select(t => new Coding()
            {
                ID = t.ID,
                ObjectType = ObjectType.Story
            }).ToList();

            var response = baseController.Insert(codings);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var codingResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codings = codingResult.Content.ToList();

            var response = baseController.Update(codings);
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
            var _codings = GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codings = _codings.Content.ToList();

            var response = baseController.GetByID(codings[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _codings = GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codingIDs = _codings.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(codingIDs);
            return response;
        }
    }
    [TestClass]
    public class CodingTest
    {
       
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CodingImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CodingImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var codingResult = CodingImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            // Assert
            Assert.IsNotNull(codingResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var codingResult = CodingImplementaion.GetByID() as OkNegotiatedContentResult<Coding>;
            // Assert
            Assert.IsNotNull(codingResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = CodingImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

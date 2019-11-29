using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using apiModel = Taha.Repository.Models;

namespace Taha.WebAPI.Tests.APIControllerTest
{
    internal class DetailImplementaion
    {
        private static DetailController baseController;

        static DetailImplementaion()
        {
            //Arrange
            baseController = new DetailController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var details = new List<apiModel.Detail>()
            {
                new apiModel.Detail(){ID = Guid.NewGuid(), Description = "Description Text A", Periority = 1, Caption = "Caption A"},
                new apiModel.Detail(){ID = Guid.NewGuid(), Description = "Description Text B", Periority = 2, Caption = "Caption B"},
                new apiModel.Detail(){ID = Guid.NewGuid(), Description = "Description Text C", Periority = 3, Caption = "Caption C"},
                new apiModel.Detail(){ID = Guid.NewGuid(), Description = "Description Text D", Periority = 4, Caption = "Caption D"},
            };
            var response = baseController.Insert(details);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var detailResult = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            var details = detailResult.Content.ToList();

            details.ForEach(t => { t.Caption = t.Caption + " Updated "; });

            var response = baseController.Update(details);
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
            var _details = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            var Details = _details.Content.ToList();

            var response = baseController.GetByID(Details[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _details = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            var detailIDs = _details.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(detailIDs);
            return response;
        }
    }

    [TestClass]
    public class DetailTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = DetailImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = DetailImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var detailResult = DetailImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            // Assert
            Assert.IsNotNull(detailResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var detailResult = DetailImplementaion.GetByID() as OkNegotiatedContentResult<apiModel.Detail>;
            // Assert
            Assert.IsNotNull(detailResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = DetailImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

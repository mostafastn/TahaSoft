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
    internal class AboutUSImplementaion
    {
        private static AboutUSController baseController;

        static AboutUSImplementaion()
        {
            //Arrange
            baseController = new AboutUSController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var AboutUSs = new List<apiModel.AboutUS>()
            {
                new apiModel.AboutUS(){ID = Guid.NewGuid(), Description = "Description Text A", Periority = 1, Caption = "Caption A"},
                new apiModel.AboutUS(){ID = Guid.NewGuid(), Description = "Description Text B", Periority = 2, Caption = "Caption B"},
                new apiModel.AboutUS(){ID = Guid.NewGuid(), Description = "Description Text C", Periority = 3, Caption = "Caption C"},
                new apiModel.AboutUS(){ID = Guid.NewGuid(), Description = "Description Text D", Periority = 4, Caption = "Caption D"},
            };
            var response = baseController.Insert(AboutUSs);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var AboutUSResult = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            var AboutUSs = AboutUSResult.Content.ToList();

            AboutUSs.ForEach(t => { t.Caption = t.Caption + " Updated "; });

            var response = baseController.Update(AboutUSs);
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
            var _AboutUSs = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            var AboutUSs = _AboutUSs.Content.ToList();

            var response = baseController.GetByID(AboutUSs[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _AboutUSs = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            var AboutUSIDs = _AboutUSs.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(AboutUSIDs);
            return response;
        }
    }

    [TestClass]
    public class AboutUSTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = AboutUSImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = AboutUSImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var AboutUSResult = AboutUSImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.AboutUS>>;
            // Assert
            Assert.IsNotNull(AboutUSResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var AboutUSResult = AboutUSImplementaion.GetByID() as OkNegotiatedContentResult<apiModel.AboutUS>;
            // Assert
            Assert.IsNotNull(AboutUSResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = AboutUSImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

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

    [TestClass]
    public class DetailTest
    {
        private DetailController baseController;

        public DetailTest()
        {
            //Arrange
            baseController = new DetailController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act

            var details = new List<apiModel.Detail>()
            {
                new apiModel.Detail()
                    {ID = Guid.NewGuid(), Description = "Description Text A", Periority = 1, Caption = "Caption A"},
                new apiModel.Detail()
                    {ID = Guid.NewGuid(), Description = "Description Text B", Periority = 2, Caption = "Caption B"},
                new apiModel.Detail()
                    {ID = Guid.NewGuid(), Description = "Description Text C", Periority = 3, Caption = "Caption C"},
                new apiModel.Detail()
                    {ID = Guid.NewGuid(), Description = "Description Text D", Periority = 4, Caption = "Caption D"},
            };
            

            var response = baseController.Insert(details) as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var detailResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            var details = detailResult.Content.ToList();

            details.ForEach(t => { t.Caption = t.Caption + " Updated "; });

            var response = baseController.Update(details) as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var detailResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;

            // Assert
            Assert.IsNotNull(detailResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _details = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;
            var details = _details.Content.ToList();

            var detailResult = baseController.GetByID(details[0].ID) as OkNegotiatedContentResult<apiModel.Detail>;

            // Assert
            Assert.IsNotNull(detailResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Detail>>;

            var detailIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(detailIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

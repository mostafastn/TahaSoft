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
    internal class DetailAssignmentImplementaion
    {
        private static DetailAssignmentController baseController;

        static DetailAssignmentImplementaion()
        {
            //Arrange
            baseController = new DetailAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var detailResult = DetailImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Detail>>;
            var detailList = detailResult.Content.ToList();

            var codingResult = CodingImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codingList = codingResult.Content.ToList();

            var DetailAssignments = detailList.Select(t => new DetailAssignment
            {
                ID = Guid.NewGuid(),
                DetailID = t.ID,
                CodingID = codingList[0].ID,
            }).ToList();

            var response = baseController.Insert(DetailAssignments);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var detailAssignmentResult = GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            var detailAssignments = detailAssignmentResult.Content.ToList();

            var response = baseController.Update(detailAssignments);
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
            var _detailAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            var detailAssignments = _detailAssignments.Content.ToList();

            var response = baseController.GetByID(detailAssignments[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _detailAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            var detailAssignmentIDs = _detailAssignments.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(detailAssignmentIDs);
            return response;
        }
    }

    [TestClass]
    public class DetailAssignmentTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = DetailAssignmentImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = DetailAssignmentImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var detailAssignmentResult = DetailAssignmentImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            // Assert
            Assert.IsNotNull(detailAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var detailAssignmentResult = DetailAssignmentImplementaion.GetByID() as OkNegotiatedContentResult<DetailAssignment>;
            // Assert
            Assert.IsNotNull(detailAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = DetailAssignmentImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

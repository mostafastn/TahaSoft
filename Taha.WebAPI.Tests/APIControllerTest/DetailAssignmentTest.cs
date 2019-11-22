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
    public class DetailAssignmentTest
    {
        private DetailAssignmentController baseController;

        public DetailAssignmentTest()
        {
            //Arrange
            baseController = new DetailAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var detailAssignments = new List<DetailAssignment>()
            {
                new DetailAssignment() { ID = Guid.NewGuid(),DetailID = Guid.Parse("bf9a5389-bd3f-42b5-886a-c7b47128e731"), CodingID = Guid.Parse("1136c853-ba53-4eb8-a40a-1d04d8a37bf7")},
                new DetailAssignment() { ID = Guid.NewGuid(),DetailID = Guid.Parse("964d3c2b-6956-4bc2-b08b-644f086cee57"), CodingID = Guid.Parse("1136c853-ba53-4eb8-a40a-1d04d8a37bf7")},
                new DetailAssignment() { ID = Guid.NewGuid(),DetailID= Guid.Parse("81ab3034-946b-49ae-a346-4446330949a1"), CodingID = Guid.Parse("1136c853-ba53-4eb8-a40a-1d04d8a37bf7")},
            };

            var response = baseController.Insert(detailAssignments) as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var detailAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            var Details = detailAssignmentResult.Content.ToList();

            Details.ForEach(t => { t.DetailID = t.DetailID; });

            var response = baseController.Update(Details) as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var detailAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            // Assert
            Assert.IsNotNull(detailAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _DetailAssignments = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;
            var detailAssignments = _DetailAssignments.Content.ToList();

            var detailAssignmentResult = baseController.GetByID(detailAssignments[0].ID) as OkNegotiatedContentResult<DetailAssignment>;

            // Assert
            Assert.IsNotNull(detailAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            var detailAssignmentIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(detailAssignmentIDs) as OkNegotiatedContentResult<IEnumerable<DetailAssignment>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

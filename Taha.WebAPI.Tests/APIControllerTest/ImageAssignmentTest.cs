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
    public class ImageAssignmentTest
    {
        private ImageAssignmentController baseController;

        public ImageAssignmentTest()
        {
            //Arrange
            baseController = new ImageAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var ImageAssignments = new List<ImageAssignment>()
            {
                new ImageAssignment() { ID = Guid.NewGuid(),ImageID = Guid.Parse("48ec2d28-57be-4071-9aea-ce06ca22f98d"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
                new ImageAssignment() { ID = Guid.NewGuid(),ImageID = Guid.Parse("48ec2d28-57be-4071-9aea-ce06ca22f98d"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
                new ImageAssignment() { ID = Guid.NewGuid(),ImageID = Guid.Parse("48ec2d28-57be-4071-9aea-ce06ca22f98d"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
            };

            var response = baseController.Insert(ImageAssignments) as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var ImageAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            var stores = ImageAssignmentResult.Content.ToList();

            stores.ForEach(t => { t.ImageID = t.ImageID; });

            var response = baseController.Update(stores) as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var ImageAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;

            // Assert
            Assert.IsNotNull(ImageAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _ImageAssignments = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            var ImageAssignments = _ImageAssignments.Content.ToList();

            var ImageAssignmentResult = baseController.GetByID(ImageAssignments[0].ID) as OkNegotiatedContentResult<ImageAssignment>;

            // Assert
            Assert.IsNotNull(ImageAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;

            var ImageAssignmentIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(ImageAssignmentIDs) as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

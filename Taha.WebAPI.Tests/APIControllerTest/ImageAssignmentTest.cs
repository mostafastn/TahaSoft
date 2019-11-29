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
using apiModel = Taha.Repository.Models;

namespace Taha.WebAPI.Tests.APIControllerTest
{
    internal class ImageAssignmentImplementaion
    {
        private static ImageAssignmentController baseController;

        static ImageAssignmentImplementaion()
        {
            //Arrange
            baseController = new ImageAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var imageResult = ImageImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var imageList = imageResult.Content.ToList();

            var codingResult = CodingImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codingList = codingResult.Content.ToList();

            var ImageAssignments = imageList.Select(t => new ImageAssignment
            {
                ID = Guid.NewGuid(),
                ImageID = t.ID,
                CodingID = codingList[0].ID,
            }).ToList();

            var response = baseController.Insert(ImageAssignments);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var imageAssignmentResult = GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            var imageAssignments = imageAssignmentResult.Content.ToList();

            var response = baseController.Update(imageAssignments);
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
            var _imageAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            var imageAssignments = _imageAssignments.Content.ToList();

            var response = baseController.GetByID(imageAssignments[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _imageAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            var imageAssignmentIDs = _imageAssignments.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(imageAssignmentIDs);
            return response;
        }
    }

    [TestClass]
    public class ImageAssignmentTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = ImageAssignmentImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = ImageAssignmentImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var ImageAssignmentResult = ImageAssignmentImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<ImageAssignment>>;
            // Assert
            Assert.IsNotNull(ImageAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var ImageAssignmentResult = ImageAssignmentImplementaion.GetByID() as OkNegotiatedContentResult<ImageAssignment>;
            // Assert
            Assert.IsNotNull(ImageAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = ImageAssignmentImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

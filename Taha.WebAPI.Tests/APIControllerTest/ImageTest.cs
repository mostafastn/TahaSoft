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
    internal class ImageImplementaion
    {
        private static ImageController baseController;

        static ImageImplementaion()
        {
            //Arrange
            baseController = new ImageController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var images = new List<apiModel.Image>()
            {
                new apiModel.Image(){ID = Guid.NewGuid(), AlternativeText = "AlternativeText A", Periority = 1, Path= "Path A"},
                new apiModel.Image(){ID = Guid.NewGuid(), AlternativeText = "AlternativeText B", Periority = 2, Path= "Path B"},
                new apiModel.Image(){ID = Guid.NewGuid(), AlternativeText = "AlternativeText C", Periority = 3, Path= "Path C"},
                new apiModel.Image(){ID = Guid.NewGuid(), AlternativeText = "AlternativeText D", Periority = 4, Path= "Path D"},
            };
            var response = baseController.Insert(images);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var imageResult = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var images = imageResult.Content.ToList();

            images.ForEach(t => { t.AlternativeText = t.AlternativeText + " Updated "; });

            var response = baseController.Update(images);
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
            var _images = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var images = _images.Content.ToList();

            var response = baseController.GetByID(images[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _images = GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var imageIDs = _images.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(imageIDs);
            return response;
        }
    }
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = ImageImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = ImageImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var imageResult = ImageImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            // Assert
            Assert.IsNotNull(imageResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var imageResult = ImageImplementaion.GetByID() as OkNegotiatedContentResult<apiModel.Image>;
            // Assert
            Assert.IsNotNull(imageResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = ImageImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

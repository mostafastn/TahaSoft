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
    public class ImageTest
    {
        private ImageController baseController;

        public ImageTest()
        {
            //Arrange
            baseController = new ImageController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            
            var images = new List<apiModel.Image>()
            {
                new apiModel.Image() { ID = Guid.NewGuid() , AlternativeText = "AlternativeText A", Periority = 0, Path = "Path A"},
                new apiModel.Image() { ID = Guid.NewGuid() , AlternativeText = "AlternativeText B", Periority = 0, Path = "Path B"},
                new apiModel.Image() { ID = Guid.NewGuid() , AlternativeText = "AlternativeText C", Periority = 0, Path = "Path C"},
                new apiModel.Image() { ID = Guid.NewGuid() , AlternativeText = "AlternativeText D", Periority = 0, Path = "Path D"},
            };

            var response = baseController.Insert(images) as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var imageResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var images= imageResult.Content.ToList();

            images.ForEach(t => { t.AlternativeText = t.AlternativeText+ " Updated "; });

            var response = baseController.Update(images) as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var imageResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;

            // Assert
            Assert.IsNotNull(imageResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _images = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;
            var imagess = _images.Content.ToList();

            var imageResult = baseController.GetByID(imagess[0].ID) as OkNegotiatedContentResult<apiModel.Image>;

            // Assert
            Assert.IsNotNull(imageResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<apiModel.Image>>;

            var imageIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(imageIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

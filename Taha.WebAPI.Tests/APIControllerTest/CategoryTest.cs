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
    public class PlaceTest
    {
        private PlaceController baseController;

        public PlaceTest()
        {
            //Arrange
            baseController = new PlaceController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var minePlaceId = Guid.NewGuid();
            var Places = new List<Place>()
            {
                new Place() { ID = minePlaceId , Name = "Main Place", Periority = 0},
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest A", Periority = 1,ParentID = minePlaceId },
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest B", Periority = 2,ParentID = minePlaceId },
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest C", Periority = 3,ParentID = minePlaceId },
            };

            var response = baseController.Insert(Places) as OkNegotiatedContentResult<IEnumerable<Place>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var PlaceResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            var Places = PlaceResult.Content.ToList();

            Places.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(Places) as OkNegotiatedContentResult<IEnumerable<Place>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var PlaceResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;

            // Assert
            Assert.IsNotNull(PlaceResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _Places = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            var Places = _Places.Content.ToList();

            var PlaceResult = baseController.GetByID(Places[0].ID) as OkNegotiatedContentResult<Place>;

            // Assert
            Assert.IsNotNull(PlaceResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;

            var PlaceIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(PlaceIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

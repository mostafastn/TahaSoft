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
    internal class PlaceImplementaion
    {
        private static PlaceController baseController;

        static PlaceImplementaion()
        {
            //Arrange
            baseController = new PlaceController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var minePlaceId = Guid.NewGuid();
            var places = new List<Place>()
            {
                new Place() { ID = minePlaceId , Name = "Main Place", Periority = 0},
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest A", Periority = 1,ParentID = minePlaceId },
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest B", Periority = 2,ParentID = minePlaceId },
                new Place() { ID = Guid.NewGuid(),Name = "PlaceTest C", Periority = 3,ParentID = minePlaceId },
            };
            var response = baseController.Insert(places);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var placeResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            var places = placeResult.Content.ToList();

            places.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(places);
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
            var _places = GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            var places = _places.Content.ToList();

            var response = baseController.GetByID(places[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _places = GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            var placeIDs = _places.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(placeIDs);
            return response;
        }
    }

    [TestClass]
    public class PlaceTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = PlaceImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Place>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = PlaceImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Place>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var PlaceResult = PlaceImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Place>>;
            // Assert
            Assert.IsNotNull(PlaceResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var PlaceResult = PlaceImplementaion.GetByID() as OkNegotiatedContentResult<Place>;
            // Assert
            Assert.IsNotNull(PlaceResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = PlaceImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

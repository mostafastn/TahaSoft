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
    internal class CarouselSlideImplementaion
    {
        private static CarouselSlideController baseController;

        static CarouselSlideImplementaion()
        {
            //Arrange
            baseController = new CarouselSlideController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult insert()
        {
            var CarouselSlides = new List<CarouselSlide>()
            {
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest A", SourceAddress = "1", Active = true},
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest B", SourceAddress = "2", Active = false},
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest C", SourceAddress = "3", Active = false},
            };

            var response = baseController.Insert(CarouselSlides);
            return response;
        }
        internal static IHttpActionResult update()
        {
            var carouselSlideResult = GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            var carouselSlides = carouselSlideResult.Content.ToList();

            carouselSlides.ForEach(t => { t.AlternateText = t.AlternateText + " Updated "; });

            var response = baseController.Update(carouselSlides);
            return response;
        }
        internal static IHttpActionResult GetAll()
        {
            insert();
            var response = baseController.GetAll();
            return response;
        }
        internal static IHttpActionResult GetByID()
        {
            var _carouselSlides = GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            var carouselSlides = _carouselSlides.Content.ToList();

            var response = baseController.GetByID(carouselSlides[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _carouselSlides = GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            var carouselSlideIDs = _carouselSlides.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(carouselSlideIDs);
            return response;
        }
    }

    [TestClass]
    public class CarouselSlideTest
    {
        private CarouselSlideController baseController;

        public CarouselSlideTest()
        {
            //Arrange
            baseController = new CarouselSlideController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CarouselSlideImplementaion.insert() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CarouselSlideImplementaion.update() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            //Act
            var response = CarouselSlideImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            //Act
            var response = CarouselSlideImplementaion.GetByID() as OkNegotiatedContentResult<CarouselSlide>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var response = CarouselSlideImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(response);
        }

    }
}

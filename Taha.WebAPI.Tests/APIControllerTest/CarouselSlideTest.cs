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
            var CarouselSlides = new List<CarouselSlide>()
            {
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest A", SourceAddress = "1", Active = true},
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest B", SourceAddress = "2", Active = false},
                new CarouselSlide() { ID = Guid.NewGuid(),AlternateText = "CarouselSlideTest C", SourceAddress = "3", Active = false},
            };

            var response = baseController.Insert(CarouselSlides) as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var CarouselSlideResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            var CarouselSlides = CarouselSlideResult.Content.ToList();

            CarouselSlides.ForEach(t => { t.AlternateText = t.AlternateText + " Updated "; });

            var response = baseController.Update(CarouselSlides) as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var CarouselSlideResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;

            // Assert
            Assert.IsNotNull(CarouselSlideResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _CarouselSlides = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;
            var CarouselSlides = _CarouselSlides.Content.ToList();

            var CarouselSlideResult = baseController.GetByID(CarouselSlides[0].ID) as OkNegotiatedContentResult<CarouselSlide>;

            // Assert
            Assert.IsNotNull(CarouselSlideResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CarouselSlide>>;

            var CarouselSlideIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(CarouselSlideIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

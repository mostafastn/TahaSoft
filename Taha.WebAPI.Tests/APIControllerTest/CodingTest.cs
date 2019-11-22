using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using Taha.Framework.Infrastructure;
using Taha.Repository.Models;


namespace Taha.WebAPI.Tests.APIControllerTest
{
    [TestClass]
    public class CodingTest
    {
        private CodingController baseController;
        private StoreController storeController;

        public CodingTest()
        {
            //Arrange
            baseController = new CodingController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            storeController = new StoreController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var _store = storeController.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var store = _store.Content.ToList();
            if (store == null)
                Assert.IsNotNull(store);

            var storeResult = storeController.GetByID(store[0].ID) as OkNegotiatedContentResult<Store>;
            var coding = new List<Coding>()
            {
                new Coding()
                {
                    ID = storeResult.Content.ID,
                    ObjectType = ObjectType.Story,
                }
            };

            var response = baseController.Insert(coding) as OkNegotiatedContentResult<IEnumerable<Coding>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var codingResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codings = codingResult.Content.ToList();

            codings.ForEach(t => { t.ObjectType= ObjectType.Story ; });

            var response = baseController.Update(codings) as OkNegotiatedContentResult<IEnumerable<Coding>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var codingResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;

            // Assert
            Assert.IsNotNull(codingResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _Coding = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codings = _Coding.Content.ToList();

            var codingResult = baseController.GetByID(codings[0].ID) as OkNegotiatedContentResult<Coding>;

            // Assert
            Assert.IsNotNull(codingResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;

            var codingIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(codingIDs) as OkNegotiatedContentResult<IEnumerable<Coding>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

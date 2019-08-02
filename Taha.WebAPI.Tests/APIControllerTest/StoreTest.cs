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
    public class StoreTest
    {
        private StoreController baseController;

        public StoreTest()
        {
            //Arrange
            baseController = new StoreController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var stores = new List<Store>()
            {
                new Store() { ID = Guid.NewGuid(),Name = "Store A", IntroductionSummary = "IntroductionSummary 1", Link = "Link A"},
                new Store() { ID = Guid.NewGuid(),Name = "Store B", IntroductionSummary = "IntroductionSummary 2", Link = "Link B"},
                new Store() { ID = Guid.NewGuid(),Name = "Store C", IntroductionSummary = "IntroductionSummary 3", Link = "Link C"},
            };

            var response = baseController.Insert(stores) as OkNegotiatedContentResult<IEnumerable<Store>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var storeResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var stores = storeResult.Content.ToList();

            stores.ForEach(t => { t.IntroductionSummary = t.IntroductionSummary + " Updated "; });

            var response = baseController.Update(stores) as OkNegotiatedContentResult<IEnumerable<Store>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var storeResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;

            // Assert
            Assert.IsNotNull(storeResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _Stores = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var stores = _Stores.Content.ToList();

            var storeResult = baseController.GetByID(stores[0].ID) as OkNegotiatedContentResult<Store>;

            // Assert
            Assert.IsNotNull(storeResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;

            var storeIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(storeIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

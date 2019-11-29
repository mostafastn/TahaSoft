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
    internal class StoreImplementaion
    {
        private static StoreController baseController;

        static StoreImplementaion()
        {
            //Arrange
            baseController = new StoreController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var Stores = new List<Store>()
            {
                new Store() { ID = Guid.NewGuid(),Name = "StoreTest A", IntroductionSummary= "IntroductionSummary A", Link = "Link A"},
                new Store() { ID = Guid.NewGuid(),Name = "StoreTest B", IntroductionSummary= "IntroductionSummary B", Link = "Link B"},
                new Store() { ID = Guid.NewGuid(),Name = "StoreTest C", IntroductionSummary= "IntroductionSummary C", Link = "Link C"},
            };
            var response = baseController.Insert(Stores);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var StoreResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var Stores = StoreResult.Content.ToList();

            Stores.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(Stores);
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
            var _Stores = GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var Stores = _Stores.Content.ToList();

            var response = baseController.GetByID(Stores[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _Stores = GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            var StoreIDs = _Stores.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(StoreIDs);
            return response;
        }
    }

    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = StoreImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Store>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = StoreImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Store>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var storeResult = StoreImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Store>>;
            // Assert
            Assert.IsNotNull(storeResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var storeResult = StoreImplementaion.GetByID() as OkNegotiatedContentResult<Store>;
            // Assert
            Assert.IsNotNull(storeResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = StoreImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

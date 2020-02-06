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

    internal class CategoryImplementaion
    {
        private static CategoryController baseController;

        static CategoryImplementaion()
        {
            //Arrange
            baseController = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var mineCategoryId = Guid.NewGuid();
            var categorys = new List<Category>()
            {
                new Category() { ID = mineCategoryId , Name = "Main category", Periority = 0},
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest A", Periority = 1,ParentID = mineCategoryId },
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest B", Periority = 2,ParentID = mineCategoryId },
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest C", Periority = 3,ParentID = mineCategoryId },
            };
            var response = baseController.Insert(categorys);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var categoryResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorys = categoryResult.Content.ToList();

            categorys.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(categorys);
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
            var _categorys = GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorys = _categorys.Content.ToList();

            var response = baseController.GetByID(categorys[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            ProductImplementaion.Delete();

            var _categorys = GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categoryIDs = _categorys.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(categoryIDs);
            return response;
        }
    }

    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CategoryImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Category>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CategoryImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Category>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            //Act
            var response = CategoryImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            //Act
            var response = CategoryImplementaion.GetByID() as OkNegotiatedContentResult<Category>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var response = CategoryImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(response);
        }

    }
}

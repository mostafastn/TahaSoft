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
    public class CategoryTest
    {
        private CategoryController baseController;

        public CategoryTest()
        {
            //Arrange
            baseController = new CategoryController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var mineCategoryId = Guid.NewGuid();
            var categorys = new List<Category>()
            {
                new Category() { ID = mineCategoryId , Name = "Main category", Periority = 0},
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest A", Periority = 1,ParentID = mineCategoryId },
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest B", Periority = 2,ParentID = mineCategoryId },
                new Category() { ID = Guid.NewGuid(),Name = "categoryTest C", Periority = 3,ParentID = mineCategoryId },
            };

            var response = baseController.Insert(categorys) as OkNegotiatedContentResult<IEnumerable<Category>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var categoryResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorys = categoryResult.Content.ToList();

            categorys.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = baseController.Update(categorys) as OkNegotiatedContentResult<IEnumerable<Category>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var categoryResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;

            // Assert
            Assert.IsNotNull(categoryResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _categorys = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorys = _categorys.Content.ToList();

            var categoryResult = baseController.GetByID(categorys[0].ID) as OkNegotiatedContentResult<Category>;

            // Assert
            Assert.IsNotNull(categoryResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;

            var categoryIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(categoryIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

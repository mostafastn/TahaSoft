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
    public class CategoryAssignmentTest
    {
        private CategoryAssignmentController baseController;

        public CategoryAssignmentTest()
        {
            //Arrange
            baseController = new CategoryAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var categoryAssignments = new List<CategoryAssignment>()
            {
                new CategoryAssignment() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("157f57e0-b219-4527-983a-146207756826"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
                new CategoryAssignment() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("5a40ba1e-ccf5-4dd3-81ed-52df64573b64"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
                new CategoryAssignment() { ID = Guid.NewGuid(),CategoryID = Guid.Parse("fb5669bf-e741-4652-9a7e-873a359ff3df"), CodingID = Guid.Parse("a725c83b-237c-4d8b-98df-c2351bbd72a0")},
            };

            var response = baseController.Insert(categoryAssignments) as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var categoryAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            var stores = categoryAssignmentResult.Content.ToList();

            stores.ForEach(t => { t.CategoryID = t.CategoryID; });

            var response = baseController.Update(stores) as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var categoryAssignmentResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;

            // Assert
            Assert.IsNotNull(categoryAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _CategoryAssignments = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            var categoryAssignments = _CategoryAssignments.Content.ToList();

            var categoryAssignmentResult = baseController.GetByID(categoryAssignments[0].ID) as OkNegotiatedContentResult<CategoryAssignment>;

            // Assert
            Assert.IsNotNull(categoryAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;

            var categoryAssignmentIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(categoryAssignmentIDs) as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

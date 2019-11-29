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
    internal class CategoryAssignmentImplementaion
    {
        private static CategoryAssignmentController baseController;

        static CategoryAssignmentImplementaion()
        {
            //Arrange
            baseController = new CategoryAssignmentController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var categoryResult = CategoryImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Category>>;
            var categorieList = categoryResult.Content.ToList();

            var codingResult = CodingImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Coding>>;
            var codingList = codingResult.Content.ToList();

            var categoryAssignments = categorieList.Select(t => new CategoryAssignment
            {
                ID = Guid.NewGuid(),
                CategoryID = t.ID,
                CodingID = codingList[0].ID,
            }).ToList();

            var response = baseController.Insert(categoryAssignments);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var categoryAssignmentResult = GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            var categoryAssignments = categoryAssignmentResult.Content.ToList();
            
            var response = baseController.Update(categoryAssignments);
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
            var _categoryAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            var categoryAssignments = _categoryAssignments.Content.ToList();

            var response = baseController.GetByID(categoryAssignments[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _categoryAssignments = GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            var categoryAssignmentIDs = _categoryAssignments.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(categoryAssignmentIDs);
            return response;
        }
    }

    [TestClass]
    public class CategoryAssignmentTest
    {
       
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CategoryAssignmentImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CategoryAssignmentImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var categoryAssignmentResult = CategoryAssignmentImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<CategoryAssignment>>;
            // Assert
            Assert.IsNotNull(categoryAssignmentResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var categoryAssignmentResult = CategoryAssignmentImplementaion.GetByID() as OkNegotiatedContentResult<CategoryAssignment>;
            // Assert
            Assert.IsNotNull(categoryAssignmentResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = CategoryAssignmentImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

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
    internal class UserImplementaion
    {
        private static UserController baseController;

        static UserImplementaion()
        {
            //Arrange
            baseController = new UserController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var personResult = PersonImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var personList = personResult.Content.ToList();

            var users = personList.Select(t => new User()
            {
                ID = Guid.NewGuid(),
                PersonID = t.ID,
                UserName = "UserName",
                Password = "Password",
                Active = true,
            }).ToList();

            var response = baseController.Insert(users);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var userResult = GetAll() as OkNegotiatedContentResult<IEnumerable<User>>;
            var users = userResult.Content.ToList();

            var response = baseController.Update(users);
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
            var _users = GetAll() as OkNegotiatedContentResult<IEnumerable<User>>;
            var userss = _users.Content.ToList();

            var response = baseController.GetByID(userss[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            //var cartResult = CartImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;

            var _users = GetAll() as OkNegotiatedContentResult<IEnumerable<User>>;
            var userIDs = _users.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(userIDs);
            return response;
        }
    }
    [TestClass]
    public class UserTest
    {
       
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = UserImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<User>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = UserImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<User>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var response = UserImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<User>>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var response = UserImplementaion.GetByID() as OkNegotiatedContentResult<User>;
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var response = UserImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(response);
        }

    }
}

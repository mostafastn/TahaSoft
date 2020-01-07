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
    internal class PersonImplementaion
    {
        private static PersonController baseController;

        static PersonImplementaion()
        {
            //Arrange
            baseController = new PersonController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var persons = new List<Person>()
            {
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName A", LastName = "LastName A", SSN = "SSN A" , Phone = "Phone A" , Email ="Email A" , Address = "Address A"},
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName B", LastName = "LastName B", SSN = "SSN B" , Phone = "Phone B" , Email ="Email B" , Address = "Address B"},
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName C", LastName = "LastName C", SSN = "SSN C" , Phone = "Phone C" , Email ="Email C" , Address = "Address C"},
            };
            var response = baseController.Insert(persons);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var personResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var persons = personResult.Content.ToList();

            persons.ForEach(t => { t.FirstName = t.FirstName + " Updated "; });

            var response = baseController.Update(persons);
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
            var _persons = GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var persons = _persons.Content.ToList();

            var response = baseController.GetByID(persons[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            CustomerImplementaion.Delete();
            UserImplementaion.Delete();

            var _persons = GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var personIDs = _persons.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(personIDs);
            return response;
        }
    }

    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = PersonImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Person>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = PersonImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Person>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var personResult = PersonImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            // Assert
            Assert.IsNotNull(personResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var personResult = PersonImplementaion.GetByID() as OkNegotiatedContentResult<Person>;
            // Assert
            Assert.IsNotNull(personResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = PersonImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

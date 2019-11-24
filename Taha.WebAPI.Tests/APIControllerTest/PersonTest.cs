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
    public class PersonTest
    {
        private PersonController baseController;

        public PersonTest()
        {
            //Arrange
            baseController = new PersonController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }

        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var persons = new List<Person>()
            {
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName A", LastName = "LastName A", SSN = "SSN A" , Phone = "Phone A" , Email ="Email A" , Address = "Address A"},
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName B", LastName = "LastName B", SSN = "SSN B" , Phone = "Phone B" , Email ="Email B" , Address = "Address B"},
                new Person() { ID = Guid.NewGuid(),FirstName = "FirstName C", LastName = "LastName C", SSN = "SSN C" , Phone = "Phone C" , Email ="Email C" , Address = "Address C"},
            };

            var response = baseController.Insert(persons) as OkNegotiatedContentResult<IEnumerable<Person>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act

            var personResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var persons = personResult.Content.ToList();

            persons.ForEach(t => { t.FirstName = t.FirstName + " Updated "; });

            var response = baseController.Update(persons) as OkNegotiatedContentResult<IEnumerable<Person>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act

            var personResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;

            // Assert
            Assert.IsNotNull(personResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act

            var _Persons = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var persons = _Persons.Content.ToList();

            var personResult = baseController.GetByID(persons[0].ID) as OkNegotiatedContentResult<Person>;

            // Assert
            Assert.IsNotNull(personResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var getAllResult = baseController.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;

            var personIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = baseController.Delete(personIDs) as OkNegotiatedContentResult<IEnumerable<Person>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}

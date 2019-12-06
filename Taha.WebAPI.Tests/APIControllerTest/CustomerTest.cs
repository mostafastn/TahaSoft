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
    internal class CustomerImplementaion
    {
        private static CustomerController baseController;

        static CustomerImplementaion()
        {
            //Arrange
            baseController = new CustomerController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
        }
        internal static IHttpActionResult Insert()
        {
            var personResult = PersonImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Person>>;
            var personList = personResult.Content.ToList();

            var customers = personList.Select(t => new Customer()
            {
                ID = t.ID
            }).ToList();

            var response = baseController.Insert(customers);
            return response;
        }
        internal static IHttpActionResult Update()
        {
            var customerResult = GetAll() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            var customers = customerResult.Content.ToList();

            var response = baseController.Update(customers);
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
            var _customers = GetAll() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            var customers = _customers.Content.ToList();

            var response = baseController.GetByID(customers[0].ID);
            return response;
        }
        internal static IHttpActionResult Delete()
        {
            var _customers = GetAll() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            var customerIDs = _customers.Content.Select(t => t.ID).ToList();
            var response = baseController.Delete(customerIDs);
            return response;
        }
    }
    [TestClass]
    public class CustomerTest
    {
       
        [TestMethod]
        public void Test_1_Insert()
        {
            //Act
            var response = CustomerImplementaion.Insert() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Act
            var response = CustomerImplementaion.Update() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
        {
            // Act
            var customerResult = CustomerImplementaion.GetAll() as OkNegotiatedContentResult<IEnumerable<Customer>>;
            // Assert
            Assert.IsNotNull(customerResult);
        }

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Act
            var customerResult = CustomerImplementaion.GetByID() as OkNegotiatedContentResult<Customer>;
            // Assert
            Assert.IsNotNull(customerResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Act
            var deleteResult = CustomerImplementaion.Delete() as OkNegotiatedContentResult<IEnumerable<Guid>>;
            //Assert
            Assert.IsNotNull(deleteResult);
        }

    }
}

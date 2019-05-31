using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using Taha.DatabaseInitilization.Domains;

namespace Taha.WebAPI.Tests.APIControllerTest
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var mineMenuId = Guid.NewGuid();
            var menus = new List<Models.Menu>()
            {
                new Models.Menu() { ID = mineMenuId , Name = "Main Menu"},
                new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest A",ParentID = mineMenuId },
                new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest B",ParentID = mineMenuId },
                new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest C",ParentID = mineMenuId },
            };

            var response = controller.Insert(menus) as OkNegotiatedContentResult<IEnumerable<TBL_Menu>>;

            // Assert
            Assert.IsNotNull(response);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taha.WebAPI.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;
using System.Web.Http.Results;
using Taha.DatabaseInitilization.Domains;
using Taha.Repository.Models;

namespace Taha.WebAPI.Tests.APIControllerTest
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            // Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            
            var menuResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;
            
            // Assert
            Assert.IsNotNull(menuResult);
        }

        //[TestMethod]
        //public void TestInsert()
        //{
        //    // Arrange
        //    var controller = new MenuController
        //    {
        //        Request = new HttpRequestMessage(),
        //        Configuration = new HttpConfiguration()
        //    };

        //    // Act
        //    var mineMenuId = Guid.NewGuid();
        //    var menus = new List<Models.Menu>()
        //    {
        //        new Models.Menu() { ID = mineMenuId , Name = "Main Menu"},
        //        new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest A",ParentID = mineMenuId },
        //        new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest B",ParentID = mineMenuId },
        //        new Models.Menu() { ID = Guid.NewGuid(),Name = "MenuTest C",ParentID = mineMenuId },
        //    };

        //    var response = controller.Insert(menus) as OkNegotiatedContentResult<IEnumerable<Taha.WebAPI.Models.Menu>>;

        //    // Assert
        //    Assert.IsNotNull(response);
        //}

        //[TestMethod]
        //public void TestUpdate()
        //{
        //    // Arrange
        //    var controller = new MenuController
        //    {
        //        Request = new HttpRequestMessage(),
        //        Configuration = new HttpConfiguration()
        //    };

        //    // Act
        //    var a = controller.GetAll();

        //    var menuResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<Taha.WebAPI.Models.Menu>>;
        //    var menus = menuResult.Content.ToList();
            
        //    menus.ForEach(t => { t.Name = t.Name + " Updated "; });

        //    var response = controller.Update(menus) as OkNegotiatedContentResult<IEnumerable<Taha.WebAPI.Models.Menu>>;

        //    // Assert
        //    Assert.IsNotNull(response);
        //}
    }
}

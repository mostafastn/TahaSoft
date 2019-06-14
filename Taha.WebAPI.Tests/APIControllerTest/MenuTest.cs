﻿using System;
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
    public class MenuTest
    {
        [TestMethod]
        public void Test_1_Insert()
        {
            //Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //Act
            var mineMenuId = Guid.NewGuid();
            var menus = new List<TreeMenu>()
            {
                new TreeMenu() { ID = mineMenuId , Name = "Main Menu"},
                new TreeMenu() { ID = Guid.NewGuid(),Name = "MenuTest A",ParentID = mineMenuId },
                new TreeMenu() { ID = Guid.NewGuid(),Name = "MenuTest B",ParentID = mineMenuId },
                new TreeMenu() { ID = Guid.NewGuid(),Name = "MenuTest C",ParentID = mineMenuId },
            };

            var response = controller.Insert(menus) as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_2_Update()
        {
            //Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //Act

            var menuResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;
            var menus = menuResult.Content.ToList();

            menus.ForEach(t => { t.Name = t.Name + " Updated "; });

            var response = controller.Update(menus) as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Test_3_GetAll()
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

        [TestMethod]
        public void Test_4_GetByID()
        {
            // Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act

            var _menus = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;
            var menus = _menus.Content.ToList();

            var menuResult = controller.GetByID(menus[0].ID) as OkNegotiatedContentResult<TreeMenu>;

            // Assert
            Assert.IsNotNull(menuResult);
        }

        [TestMethod]
        public void Test_5_Delete()
        {
            //Arrange
            var controller = new MenuController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            //Act
            var getAllResult = controller.GetAll() as OkNegotiatedContentResult<IEnumerable<TreeMenu>>;

            var menuIDs = getAllResult.Content.Select(t => t.ID).ToList();

            var deleteResult = controller.Delete(menuIDs) as OkNegotiatedContentResult<IEnumerable<Guid>>;

            //Assert
            Assert.IsNotNull(getAllResult);
        }

    }
}
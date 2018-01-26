using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain;
using WalletDomain.Services;

namespace WalletTest
{
    [TestClass]
    class UserTests
    {
        [TestMethod]
        public void Can_Add_User_To_Repository()
        {
            //Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(m => m.Add(new User("User1", "user@emial.com", "strongpassword"))).Returns(true);

            //Assert
            var result = userServiceMock.Object.Add((new User("User1", "user@emial.com", "strongpassword")));

            //Act
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Can_Get_User()
        {
            //Arrange

        }

        [TestMethod]
        public void Cant_Get_Not_Existing_User()
        {

        }

        [TestMethod]
        public void Can_Update_User()
        {

        }
    }
}

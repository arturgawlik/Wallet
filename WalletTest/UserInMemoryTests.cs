using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain;
using WalletDomain.Services;
using WalletDomain.Services.InMemory;

namespace WalletTest
{
    [TestClass]
    public class UserInMemoryTests
    {
        [TestMethod]
        public void Can_Add_User_To_Repository()
        {
            //Arrange
            IUserService userService = new UserService();

            //Assert
            var result = userService.Add(new User("TestUsername", "test@email.com", "testPassword"));

            //Act
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Can_Get_User_Existing_User()
        {
            //Arrange
            IUserService userService = new UserService();
            User user = new User("TestUsername", "test@email.com", "testPassword");

            //Act
            userService.Add(user);


            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Cant_Get_Not_Existing_User()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Can_Update_User()
        {
            //Arrange

            //Act

            //Assert
            Assert.Fail();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain;
using WalletDomain.Domain;
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
        public void Can_Get_Existing_User()
        {
            //Arrange
            IUserService userService = new UserService();
            var user = new User("TestUsername", "test@email.com", "testPassword");
            
            //Act
            var addUserToRepoResponse =  userService.Add(user);
            var getUserResponse = userService.GetById(user.Id);

            //Assert
            Assert.AreEqual(true, addUserToRepoResponse);
            Assert.AreEqual(user, getUserResponse);
        }

        [TestMethod]
        public void Cant_Get_Not_Existing_User()
        {
            //Arrange
            IUserService userService = new UserService();
            
            //Act
            var getUserResponse = userService.GetById(1);
            
            //Assert
            Assert.AreEqual(null, getUserResponse);
        }

        [TestMethod]
        public void Can_Update_User()
        {
            //Arrange
            IUserService userService = new UserService();
            var user = new User("TestUsername", "test@email.com", "testPassword");
            
            //Act
            userService.Add(user);
            var userResponse = userService.GetById(user.Id);
            
            userResponse.SetUsername("NewTestUserName");
            userResponse.SetEmail("newTest@email.com");
            userResponse.SetPassword("newTestPassword");
            userService.Update(userResponse);

            var userResponse2 = userService.GetById(userResponse.Id);
            
            //Assert
            Assert.AreEqual("NewTestUserName", userResponse2.Username);
            Assert.AreEqual("newTest@email.com", userResponse2.Email);
            Assert.AreEqual("newTestPassword", userResponse2.Password);
        }
    }
}

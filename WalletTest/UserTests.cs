//using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalletDomain;
using WalletDomain.Domain;
using WalletDomain.Exceptions;

namespace WalletTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Can_Change_Username()
        {
            //Arrange
            var user = new User("username1", "email1@email.com", "password1");
            
            //Act
            user.SetUsername("username2");
            
            //Assert
            Assert.AreEqual("username2", user.Username);
        }
        
        [TestMethod]
        public void Can_Change_User_Email()
        {
            //Arrange
            var user = new User("username1", "email1@email.com", "password1");
            
            //Act
            user.SetEmail("email2@email.com");
            
            //Assert
            Assert.AreEqual("email2@email.com", user.Email);
        }

        [TestMethod]
        public void Can_Change_User_Password()
        {
            //Arrange
            var user = new User("username1", "email1@email.com", "password1");
            
            //Act
            user.SetPassword("password2");
            
            //Assert
            Assert.AreEqual("password2", user.Password);
        }

        [TestMethod]
        public void Cant_Set_Invalid_Email()
        {
            //Arrange Act Assert
            Assert.ThrowsException<EmailException>(() => new User("username", "", "password"));
            Assert.ThrowsException<EmailException>(() => new User("username", "wrongEmail", "password"));
            Assert.ThrowsException<EmailException>(() => new User("username", "wrongEmail@", "password"));
            Assert.ThrowsException<EmailException>(() => new User("username", "@wrongEmail", "password"));
            Assert.ThrowsException<EmailException>(() => new User("username", "wrongemail@email..com", "password"));
            Assert.ThrowsException<EmailException>(() => new User("username", "wrong..email@email.com", "password"));
        }

        [TestMethod]
        public void Cant_Set_Invalid_Username()
        {
            //Arrange Act Assert
            Assert.ThrowsException<UsernameException>(() => new User("", "email@emal.com", "password"));
        }

        [TestMethod]
        public void Cant_Set_Invalid_Password()
        {
            //Arrange Act Assert
            Assert.ThrowsException<PasswordException>(() => new User("username", "email@email.com", ""));
        }
    }
}
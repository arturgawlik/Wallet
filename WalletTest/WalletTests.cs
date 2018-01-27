using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.Domain;
using WalletDomain.Exceptions;

namespace WalletTest
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void Can_Create_New_Wallet()
        {
            //Arrange Act
            var user = new User("Username", "email@email.com", "password");
            var wallet = new Wallet("WalletName", user.Id);

            //Assert
            Assert.IsNotNull(wallet);
        }

        [TestMethod]
        public void Can_Add_Money_To_The_Wallet()
        {
            //Arrange
            var user = new User("Username", "email@email.com", "password");
            var wallet = new Wallet("WalletName", user.Id);

            //Act
            wallet.Add(100);
            var result = wallet.GetBalance();

            //Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Can_Substract_Money_From_The_Wallet()
        {
            //Arrange
            var user = new User("Username", "email@email.com", "password");
            var wallet = new Wallet("WalletName", user.Id);

            //Act
            wallet.Add(100);
            wallet.Substract(50);
            var result = wallet.GetBalance();

            //Assert
            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void Cant_Substract_If_Wallet_Score_Will_Be_Less_Than_Zero_And_Options_Do_Not_Let_That()
        {
            //Arrange
            var user = new User("Username", "email@email.com", "password");
            var wallet = new Wallet("WalletName", user.Id);
            wallet.AllowDebit = false;

            //Act Assert
            wallet.Add(100);
            Assert.ThrowsException<WalletNotEnoughtFundsException>(() => wallet.Substract(120));
        }

        [TestMethod]
        public void Can_Substract_If_Wallet_Score_Will_Be_Less_Than_Zero_And_Options_Let_That()
        {
            //Arrange
            var user = new User("Username", "email@email.com", "password");
            var wallet = new Wallet("WalletName", user.Id);
            wallet.AllowDebit = true;

            //Act Assert
            wallet.Add(100);
            wallet.Substract(120);
            var result = wallet.GetBalance();

            //Assert
            Assert.AreEqual(-20, result);
        }
    }
}

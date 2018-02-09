using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WalletDomain.DB;
using WalletDomain.Domain;
using WalletDomain.Services.Services;

namespace WalletTest
{
    [TestClass]
    public class WalletServiceTests
    {
        [TestMethod]
        public void Create_new_wallet_via_context()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Wallet>>();
            var mockContext = new Mock<WalletContext>();
            mockContext.Setup(m => m.Wallets).Returns(mockSet.Object);

            var service = new WalletService(mockContext.Object);

            //Act
            service.Create(new Wallet("Wallet", 1));

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Wallet>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}

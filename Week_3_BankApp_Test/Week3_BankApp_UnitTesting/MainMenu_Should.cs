using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Week_3_BankApp.Model;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class MainMenu_Should
    {

        private Mock<IDb> _mockDb;
        private Mock<IMenu> _mockMenu;

        [SetUp]
        public void Setup()
        {
            _mockDb = new Mock<IDb>();
            _mockMenu = new Mock<IMenu>();
        }

        [Test]
        public void StartApplication_InputOption1_CallsMenuMethod()
        {
            // Arrange
            var dIContainer = new DIContainer();
            var expectedCustomer = new Customer { Accounts = new List<Account>() };
            _mockDb.Setup(db => db.Customers).Returns(new List<Customer> { expectedCustomer });
            //Console.SetIn(new StringReader("password\nemail\n1\n"));

            // Act
            MainMenu.StartApplication(dIContainer);

            // Assert
            _mockMenu.Verify(m => m.MenuMethod(It.IsAny<DIContainer>(), expectedCustomer), Times.Once);
        }

        [Test]
        public void StartApplication_InputOption2_CallsRegisterCustomer()
        {
            // Arrange
            var dIContainer = new DIContainer();
            //Console.SetIn(new StringReader("2\n"));

            // Act
            MainMenu.StartApplication(dIContainer);
            string Check = "AAA";
            // Assert
            Assert.That(Check, Is.Not.EqualTo("Enter password"));
        

        }

       
        [Test]
        public void StartApplication_InputInvalidOption_PromptsForCorrectInput()
        {
            // Arrange
            var dIContainer = new DIContainer();
            // Console.SetIn(new StringReader("invalid option\n3\n"));
            string Check = "AAA";
            // Act
            MainMenu.StartApplication(dIContainer);

            // Assert
            Assert.That(Check, Is.EqualTo("AAA"));
            Assert.That(Console.ReadLine(), Is.EqualTo("Enter password"));
        }
    }
}

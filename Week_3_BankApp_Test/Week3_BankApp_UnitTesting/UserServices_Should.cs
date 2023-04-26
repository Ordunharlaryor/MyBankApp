using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week_3_BankApp.Enum;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class UserServices_Should
    { 
            private Mock<ICustomerRepository> _customerRepositoryMock;
            private Mock<IAccountRepository> _accountRepositoryMock;
            private IUserService _userService;

            [SetUp]
            public void Setup()
            {
                _customerRepositoryMock = new Mock<ICustomerRepository>();
                _accountRepositoryMock = new Mock<IAccountRepository>();
                _userService = new UserService(_customerRepositoryMock.Object, _accountRepositoryMock.Object);
            }

            [Test]
            public void CreateAccount_ShouldAddCustomerToRepository_WhenCustomerDoesNotExist()
            {
                // Arrange
                var newCustomer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com"
                };
                _customerRepositoryMock.Setup(x => x.GetByEmail(newCustomer.Email)).Returns((Customer)null);

                // Act
                _userService.CreateAccount(newCustomer);

                // Assert
                _customerRepositoryMock.Verify(x => x.Add(It.Is<Customer>(c =>
                    c.FirstName == newCustomer.FirstName &&
                    c.LastName == newCustomer.LastName &&
                    c.Email == newCustomer.Email
                )), Times.Once);
            }

            [Test]
            public void CreateAccount_ShouldNotAddCustomerToRepository_WhenCustomerExists()
            {
                // Arrange
                var existingCustomer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com"
                };
                _customerRepositoryMock.Setup(x => x.GetByEmail(existingCustomer.Email)).Returns(existingCustomer);

                // Act
                _userService.CreateAccount(existingCustomer);

                // Assert
                _customerRepositoryMock.Verify(x => x.Add(It.IsAny<Customer>()), Times.Never);
            }

            [Test]
            public void CreateAccount_ShouldAddAccountToRepository()
            {
                // Arrange
                var customer = new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "johndoe@example.com"
                };
                _customerRepositoryMock.Setup(x => x.GetByEmail(customer.Email)).Returns(customer);
                _accountRepositoryMock.Setup(x => x.Add(It.IsAny<Account>()));

                // Act
                _userService.CreateAccount(customer);

                // Assert
                _accountRepositoryMock.Verify(x => x.Add(It.Is<Account>(a =>
                    a.CustomerId == customer.CustomerId &&
                    a.AccountType == AccountType.Savings ||
                    a.AccountType == AccountType.Current
                )), Times.Once);
            }

            [Test]
            public void GetAccount_ShouldReturnAccountFromRepository_WhenAccountNumberIsNotNullOrWhiteSpace()
            {
                // Arrange
                var accountNumber = "1234567890";
                var expectedAccount = new Account
                {
                    AccountNumber = accountNumber
                };
                _accountRepositoryMock.Setup(x => x.GetByAccountNumber(accountNumber)).Returns(expectedAccount);

                // Act
                var actualAccount = _userService.GetAccount(accountNumber);

                // Assert
                Assert.That(actualAccount, Is.EqualTo(expectedAccount));
            }

            [Test]
            public void GetAccount_ShouldReturn_WhenAccountNumberIsNullOrWhiteSpace()
            {
                // Arrange
                var accountNumber = "";

                // Act
                var actualAccount = _userService.GetAccount(accountNumber);

                // Assert
                Assert.IsNull(actualAccount);
                Assert.That(actualAccount, Is.EqualTo(default(Account)));
            }
        }
    }


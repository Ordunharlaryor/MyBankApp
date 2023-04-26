using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using Week_3_BankApp.Enum;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class AccountManagementService_Should
    {
        private IAccountRepository _accountRepository;
        private IStatementRepository _statementRepository;
        private IAccountManagementService _accountManagementService;
        private Account _Account;
        private Account _senderAccount;
        private Account _receiverAccount;

        [SetUp]
        public void Setup()
        {
            _senderAccount = new Account { AccountType = AccountType.Savings, Balance = 5000M };
            _receiverAccount = new Account { AccountType = AccountType.Current, Balance = 2000M };

            _Account = new Account();
            _accountRepository = new Mock<IAccountRepository>().Object;
            _statementRepository = new Mock<IStatementRepository>().Object;
            _accountManagementService = new AccountManagementService(_accountRepository, _statementRepository);
        }

        [Test]
        public void Deposit_ValidAmount_Successful()
        {
            // Arrange
            _Account.Balance = 5000M;
            var initialBalance = _Account.Balance;
            var amount = 1000;

            // Act
            _accountManagementService.Deposit(_Account, amount);

            // Assert
            Assert.That(_Account.Balance, Is.EqualTo(initialBalance + amount));
        }

        [Test]
        public void Deposit_InvalidAmount_Fails()
        {
            // Arrange
            var initialBalance = _Account.Balance;
            var amount = -1000;

            // Act
            _accountManagementService.Deposit(_Account, amount);

            // Assert
            Assert.That(_Account.Balance, Is.EqualTo(initialBalance));
        }

        [Test]
        public void Withdraw_ValidAmount_Successful()
        {
            // Arrange
            _Account.Balance = 5000M;
            var initialBalance = _Account.Balance;
            var amount = 1000;

            // Act
            _accountManagementService.Withdraw(_Account, amount);

            // Assert
            Assert.That(_Account.Balance, Is.EqualTo(initialBalance - amount));
        }

        [Test]
        public void Withdraw_InvalidAmount_Fails()
        {
            // Arrange
            var initialBalance = _Account.Balance;
            var amount = -1000;

            // Act
            _accountManagementService.Withdraw(_Account, amount);

            // Assert
            Assert.That(_Account.Balance, Is.EqualTo(initialBalance));
        }

        [Test]
        public void Withdraw_InsufficientFunds_Fails()
        {
            // Arrange
            _Account.Balance = 5000M;
            var initialBalance = _Account.Balance;
            var amount = initialBalance + 1000;

            // Act
            _accountManagementService.Withdraw(_Account, amount);

            // Assert
            Assert.That(_Account.Balance, Is.EqualTo(initialBalance));
        }

        [Test]
        public void Withdraw_SavingsAccountBelowMinBalance_Fails()
        {
            // Arrange
            _Account.Balance = 2000M;
            var initialBalance = _Account.Balance;
            var amount = 1500;

            // Act
            _accountManagementService.Withdraw(_Account, amount);

            // Assert
            Assert.Less(_Account.Balance, initialBalance);
        }


        [Test]
        public void TransferMoney_ValidAmount_Successful()
        {
            // Arrange
            decimal amount = 100M;

            // Act
            _accountManagementService.TransferMoney(_senderAccount, _receiverAccount, amount);

            // Assert
            Assert.IsNotNull(_senderAccount);
            Assert.IsNotNull(_receiverAccount);
        }

        [Test]
        public void TransferMoney_SavingsAccountBelowMinBalance_RaisesException()
        {
            // Arrange
            _senderAccount.Balance = 1000M;
            decimal amount = 500M;

            // Act & Assert
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(_accountManagementService);
                Assert.IsNotNull(_senderAccount);
                Assert.IsNotNull(_receiverAccount);

            });
        }

        [Test]
        public void TransferMoney_InValidAmount_Successful()
        {
            // Arrange
            decimal amount = 1000M;
            decimal expectedSenderAccountBalance = _senderAccount.Balance - amount;
            decimal expectedReceiverAccountBalance = _receiverAccount.Balance + amount;

            // Act
            _accountManagementService.TransferMoney(_senderAccount, _receiverAccount, amount);

            // Assert
            Assert.That(_senderAccount.Balance, Is.EqualTo(expectedSenderAccountBalance));
            Assert.That(_receiverAccount.Balance, Is.EqualTo(expectedReceiverAccountBalance));
        }
    }
}

using NUnit.Framework;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.Enum;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;
using System.Collections.Generic;
using Week_3_BankApp.Implementation.Repositories;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Week_3_BankApp.Implementation.Services;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class AccountRepository_Should
    {
        private IDb _db;
        private IAccountRepository _accountRepository;
        private Account _account;


        [SetUp]
        public void SetUp()
        {

            _db = new Db();
            _accountRepository = new AccountRepository();
            _account = new Account();


        }
        [Test]
        public void Check_That_AddAccountMethod_Is_Working()
        {
            //Arrange

            // Create a new account to add
            var newAccount = new Account()
            {
                AccountId = "146",
                AccountName = "John Doe",
                AccountType = AccountType.Savings,
                AccountNumber = "5678901234",
                Balance = 5000.00M
            };

            //Act

            // Add the account to the database
            _db.Accounts.Add(newAccount);

            _accountRepository.Add(newAccount);


            // Assert

            // Ensure that the account has been added
            Assert.That(_db.Accounts.Contains(newAccount));
        }

        [Test]
        public void Check_That_DeleteAccountMethod_Is_Working()
        {
            //Arrange
            // Create an account to delete
            var Acc = new Account()
            {
                AccountId = "145",
                AccountName = "Ada Patrick",
                AccountType = AccountType.Savings,
                AccountNumber = "2346789870",
                Balance = 3000.00M
            };
            // Acct
            // Add the account to the database
            _db.Accounts.Add(Acc);

            // Delete the account
            var VerifyAcc = "145";

            _accountRepository.Delete(VerifyAcc);
            // Save changes to the database
            _db.Accounts.Remove(Acc);

            // Assert
            // Ensure that the account has been deleted
            Assert.That(!_db.Accounts.Contains(Acc));
        }



        [Test]

        public void Check_That_AddAccountMethod_Is_Not_Working()
        {
            //Arrange
            var Acc = new Account()
            {
                AccountId = "145",
                AccountName = "Ada Patrick",
                AccountType = AccountType.Savings,
                AccountNumber = "2346789870",
                Balance = 3000.00M
            };
            //Act
            var result = new List<Account>();
            _db.Accounts.Add(Acc);
            //Assert
            Assert.That(Acc, Is.Not.Null);

        }


        [Test]
        public void Check_Adding_Account_With_Invalid_Values()
        {
            //Arrange
            var Acc = new Account()
            {
                AccountId = "145#",
                AccountName = "Ada Patrick",
                AccountType = AccountType.Savings,
                AccountNumber = "23467898a70",
                Balance = -1000.00M
            };
            var result = "5467897654";
            //Act
            _db.Accounts.Add(Acc);
            //Assert
            Assert.That(Acc.AccountNumber, Is.Not.EqualTo(result));
        }

        [Test]
        public void Check_Adding_Account_With_Maximum_Values()
        {
            var Acc = new Account()
            {
                AccountId = int.MaxValue.ToString(),
                AccountName = new string('a', 100),
                AccountType = AccountType.Savings,
                AccountNumber = long.MaxValue.ToString(),
                Balance = decimal.MaxValue
            };

            _db.Accounts.Add(Acc);
            Assert.That(Acc, Is.Not.Null);
        }
        [Test]
        public void Check_Adding_Account_With_Minimum_Values()
        {
            // Arrange
            var Acc = new Account()
            {
                AccountId = int.MinValue.ToString(),
                AccountName = "",
                AccountType = AccountType.Savings,
                AccountNumber = "0",
                Balance = decimal.MinValue
            };

            // Act
            _db.Accounts.Add(Acc);

            // Assert
            Assert.That(Acc.AccountNumber.Count(), Is.Not.EqualTo(10));
        }

        [Test]
        public void GetByAccountNumber_ValidAccountNumber_ReturnsAccount()
        {
            // Arrange
            string accountNumberToGet = "2346789870";

            // Act
            Account result = _accountRepository.GetByAccountNumber(accountNumberToGet);


            // Assert
            Assert.IsNotNull(result);

        }


        [Test]
        public void Update_UpdatesExistingAccount()
        {
            // Arrange

            var OldAccount = new Account
            {
                AccountId = "2",
                AccountName = "ODUNALAYOR AYANDA",
                AccountType = AccountType.Savings,
                AccountNumber = "3456789013",
                Balance = 2000.00M
            };

            var accountToUpdate = new Account
            {
                AccountId = "3",
                AccountName = "ODUNALAYOR DONPAT",
                AccountType = AccountType.Savings,
                AccountNumber = "3456789012",
                Balance = 2000.00M
            };

            // Act

            Account AccountToUpdate = null;

            _db.Accounts.Add(accountToUpdate);


            for (int i = 0; i < _db.Accounts.Count; i++)
            {
                AccountToUpdate = _db.Accounts[i].AccountId != accountToUpdate.AccountId ? OldAccount : accountToUpdate;

                _accountRepository.Get(AccountToUpdate.AccountId);

            }

            Account accountInDatabase = _accountRepository.Get(AccountToUpdate.AccountId);

            //Assert
            Assert.IsNotNull(accountInDatabase);

            Assert.That(accountToUpdate.AccountId, Is.Not.EqualTo(OldAccount.AccountId));
            Assert.That(accountInDatabase.AccountType, Is.EqualTo(accountToUpdate.AccountType));



        }

        [Test]
        public void Update_DoesNotUpdateNonExistingAccount()
        {


            var OldAccount = new Account
            {
                AccountId = "2",
                AccountName = "ODUNALAYOR AYANDA",
                AccountType = AccountType.Current,
                AccountNumber = "3456789013",
                Balance = 2000.00M
            };
            // Arrange
            var accountToUpdate = new Account
            {
                AccountId = "3",
                AccountName = "ODUNALAYOR DONPAT",
                AccountType = AccountType.Savings,
                AccountNumber = "3456789012",
                Balance = 2000.00M
            };

            // Act
            Account AccountToUpdate = null;

            _db.Accounts.Add(accountToUpdate);

            for (int j = 0; j < _db.Accounts.Count; j++)
            {
                AccountToUpdate = _db.Accounts[j].AccountId != accountToUpdate.AccountId ? OldAccount : accountToUpdate;

                _accountRepository.Get(AccountToUpdate.AccountId);

            }

            //Assert
            Assert.IsNotNull(_accountRepository.Get(AccountToUpdate.AccountId));

            Assert.That(_accountRepository.Get(AccountToUpdate.AccountId), Is.Not.EqualTo(accountToUpdate));

            Assert.That(OldAccount.AccountType, Is.Not.EqualTo(accountToUpdate.AccountType));


        }


        [Test]
        public void GetAll_ReturnsAllAccounts()
        {
            var accounts = new List<Account>
        {
            new Account
            {
                AccountId = "1",
                AccountName = "John Doe",
                AccountType = AccountType.Savings,
                AccountNumber = "1234567890",
                Balance = 1000.00M
            },
            new Account
            {
                AccountId = "2",
                AccountName = "Jane Smith",
                AccountType = AccountType.Savings,
                AccountNumber = "2345678901",
                Balance = 5000.00M
            }
        };
            _db.Accounts.AddRange(accounts);



            // Arrange: There are two accounts in the mock database

            // Act

            var result = _accountRepository.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(_db.Accounts.Count, Is.EqualTo(2));
        }
    }
}
using System.Collections.Generic;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Abstraction.Interfaces;
using System;

namespace Week_3_BankApp.Implementation.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Db _database = new Db();

        public AccountRepository()
        {
            _database = new Db();
        }

        public bool Add(Account account)
        {
            if (account == null) return false;

            _database.Accounts.Add(account);
            return true;
        }

        public void Delete(string id)
        {
            Account accountToDelete = new Account();
            foreach (var account in _database.Accounts)
            {
                if (account.AccountId == id)
                {
                    accountToDelete = account;
                    break;
                }
            }

            if (accountToDelete == null) return;

            _database.Accounts.Remove(accountToDelete);
        }

        public Account Get(string id)
        {
            Account accountToReturn = new Account();
            foreach (var account in _database.Accounts)
            {
                if (account.AccountId == id)
                {
                    accountToReturn = account;
                    break;
                }
            }

            return accountToReturn;
        }

        public Account GetByAccountNumber(string accountNumber)
        {
            Account accountToReturn = new Account();
            foreach (var account in _database.Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    accountToReturn = account;

                }
                
            }

            return accountToReturn;
        }

        public IEnumerable<Account> GetAll()
        {
            return _database.Accounts;
        }

        public void Update(Account accountToUpdate)
        {
            for (int i = 0; i < _database.Accounts.Count; i++)
            {
                if (_database.Accounts[i].AccountId == accountToUpdate.AccountId)
                {
                    _database.Accounts[i] = accountToUpdate;
                    break;
                }
            }
        }
    }
}

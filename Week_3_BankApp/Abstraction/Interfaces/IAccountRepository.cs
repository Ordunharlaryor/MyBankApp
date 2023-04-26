using System.Collections.Generic;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Repository.Abstraction
{
    public interface IAccountRepository
    {
        bool Add(Account account);
        void Delete(string id);
        void Update(Account accountToUpdate);
        Account Get(string id);
        Account GetByAccountNumber(string accountNumber);
        IEnumerable<Account> GetAll();
    }
}

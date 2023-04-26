using Week_3_BankApp.Model;

namespace Week_3_BankApp.Repository.Abstraction
{
    public interface IUserService
    {
        void CreateAccount(Customer newCustomer);
        Account GetAccount(string accountNumber);
    }
}

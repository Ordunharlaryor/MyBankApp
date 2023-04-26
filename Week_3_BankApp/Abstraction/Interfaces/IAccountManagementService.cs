using Week_3_BankApp.Model;

namespace Week_3_BankApp.Repository.Abstraction
{
    public interface IAccountManagementService
    {
        void Deposit(Account account, decimal amount);
        void Withdraw(Account account, decimal amount);
        void TransferMoney(Account senderAccount, Account receiverAccount, decimal amount);
    }
}

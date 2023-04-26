using System;
using Week_3_BankApp.Enum;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;


namespace Week_3_BankApp.Implementation.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStatementRepository _statementRepository;

        public AccountManagementService(IAccountRepository accountRepository, IStatementRepository statementRepository)
        {
            _accountRepository = accountRepository;
            _statementRepository = statementRepository;
        }
        public void Deposit(Account account, decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else
            {
                account.Balance += amount;
                Statement statement = new Statement()
                {
                    StatementDate = DateTime.Now,
                    Description = "deposit",
                    Amount = amount,
                    AccountBalance = account.Balance
                };

                _accountRepository.Update(account);
                _statementRepository.Add(statement);
                Console.WriteLine("Deposit Successful");
            }
        }

        public void Withdraw(Account account, decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else if (account.AccountType == AccountType.Savings && account.Balance - 1000 < 1000)
            {
                Console.WriteLine("Cannot withdraw less than 1000");
            }
            else
            {
                account.Balance -= amount;
                Statement statement = new Statement()
                {
                    StatementDate = DateTime.Now,
                    Description = "Withdraw",
                    Amount = amount,
                    AccountBalance = account.Balance
                };

                _accountRepository.Update(account);
                _statementRepository.Add(statement);
                Console.WriteLine("Withdrawal Successful");
            }
        }

        public void TransferMoney(Account senderAccount, Account receiverAccount, decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount range");
            }
            else if (amount > senderAccount.Balance)
            {
                Console.WriteLine("insufficient funds");
            }
            else if (senderAccount.AccountType == AccountType.Savings && senderAccount.Balance == 1000)
            {
                Console.WriteLine("Cannot withdraw less than 1000");
            }
            else
            {
                senderAccount.Balance -= amount;
                Statement senderStatement = new Statement()
                {
                    StatementDate = DateTime.Now,
                    Description = "Debited",
                    Amount = amount,
                    AccountBalance = senderAccount.Balance
                };

                _accountRepository.Update(senderAccount);
                _statementRepository.Add(senderStatement);

                receiverAccount.Balance += amount;
                Statement receiverStatement = new Statement()
                {
                    StatementDate = DateTime.Now,
                    Description = "Credited",
                    Amount = amount,
                    AccountBalance = receiverAccount.Balance
                };

                _accountRepository.Update(receiverAccount);
                _statementRepository.Add(receiverStatement);
            }
        }
    }
}

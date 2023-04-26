using System;
using Week_3_BankApp.Enum;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(ICustomerRepository customerRepository, IAccountRepository accountRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
        }

        public void CreateAccount(Customer newCustomer)
        {
            Console.WriteLine("Chooose your preferred account type");
            Console.WriteLine("1: Savings Account\n2: Current Account");
            string Option = Console.ReadLine();
            bool correct = Validation.Validate(Option);
            while (correct)
            {
                Console.WriteLine("Input correct option");
                Option = Console.ReadLine();
            }

            var customerDetails = _customerRepository.GetByEmail(newCustomer.Email);
            if (customerDetails == null)
            {
                Customer customer = new Customer()
                {
                    FirstName = newCustomer.FirstName.Trim(),
                    LastName = newCustomer.LastName.Trim(),
                    Email = newCustomer.Email.Trim()
                };
                _customerRepository.Add(customer);
                customerDetails = customer;
            }

            Account account = new Account()
            {
                CustomerId = customerDetails.CustomerId,
                AccountNumber = AccountGenerator.GeneratorUniqueAccountNumber()
            };

            if (Option == "1")
            {
                account.AccountType = AccountType.Savings;
            }
            else if (Option == "2")
            {
                account.AccountType = AccountType.Current;
            }

            _accountRepository.Add(account);
        }

        public Account GetAccount(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                return new Account();

            return _accountRepository.GetByAccountNumber(accountNumber);
        }
    }
}
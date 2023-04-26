using System;
using System.Runtime.CompilerServices;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Utilities;
using static Week_3_BankApp.Utilities.AccountTables;

namespace Week_3_BankApp.Model
{
    public class Menu : IMenu
    {
      public  void  MenuMethod(DIContainer dIContainer, Customer customer)
        {
            Console.Clear();
            Console.WriteLine("********************************************************************************************************************");
            Console.WriteLine($"Hello {customer.FirstName}, Welcome to ODUNAYOR'S BANK");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("Enter 2020: To Add Account\n any other number to see other transactions");
            var Opt = Console.ReadLine();
            int opt;
            while (!int.TryParse(Opt, out opt))
            {
                Console.WriteLine("Invalid data type! Input the valid number: ");
                Opt = Console.ReadLine();
            }
            if (opt == 2020)
            {
                dIContainer.UserService.CreateAccount(customer);
                MenuMethod(dIContainer, customer);
            }
            Console.WriteLine("1: Deposit Money\n2: Withdraw Money\n3: Check Balance\n4: Transfer Money\n5: Print Account Details\n6: Print Statement of Account\n7: Logout");
            string AccOption = Console.ReadLine();

            bool run = Validation.Validate(AccOption);
            while (run)
            {
                Console.WriteLine("Input correct option");
                AccOption = Console.ReadLine();
            }


            if (AccOption == "1")
            {
                Console.WriteLine("Enter the amount you wish to deposit");
                var Amount = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    Amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                dIContainer.AccountManagementService.Deposit(account, amount);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "2")
            {
                Console.WriteLine("Enter the amount you wish to withdraw");
                var Amount = Console.ReadLine();
                decimal amount;

                while (!decimal.TryParse(Amount, out amount))
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    Amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                dIContainer.AccountManagementService.Withdraw(account, amount);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "3")
            {
                Account account = GetAccount(customer);
                Console.WriteLine(account.Balance);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "4")
            {
                Console.WriteLine("How much do you want to transfer? ");
                var _amount = Console.ReadLine();
                decimal _amountToTransfer;

                while (!decimal.TryParse(_amount, out _amountToTransfer) || decimal.Parse(_amount) < 0)
                {
                    Console.WriteLine("Invalid Input! Input correct value: ");
                    _amount = Console.ReadLine();
                }
                Account account = GetAccount(customer);
                Console.WriteLine("Which Account number do you wish to transfer to?");
                string accNum = Console.ReadLine();
                Account destination = dIContainer.AccountRepo.GetByAccountNumber(accNum);
                if (destination.AccountNumber != null)
                {
                    dIContainer.AccountManagementService.TransferMoney(account, destination, _amountToTransfer);
                }
                else
                {
                    Console.WriteLine("You have entered an invalid account number");

                }
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {

                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "5")
            {
                Account_Tables.AccountDetails(customer);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {

                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "6")
            {
                Account account = GetAccount(customer);
                Account_Tables.PrintStatement(account);
                Console.WriteLine("Will you like to perform any other transaction");
                Console.WriteLine("1: Yes\n2: No");
                string answer = Console.ReadLine();
                bool condition = Validation.Validate(answer);
                while (condition)
                {
                    Console.WriteLine("Input correct option");
                    answer = Console.ReadLine();
                }

                if (answer == "1")
                {
                    MenuMethod(dIContainer, customer);
                }
                else if (answer == "2")
                {
                    Console.Clear();
                    MainMenu.StartApplication(dIContainer);
                }
            }
            else if (AccOption == "7")
            {
                Console.Clear();
                MainMenu.StartApplication(dIContainer);
            }
        }

        public static Account GetAccount(Customer customer)
        {
            Console.WriteLine("Which account do you want to use for this operations? ");
       
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1} {customer.Accounts[i].AccountName} {customer.Accounts[i].AccountNumber}");
            }
            Console.WriteLine("Choose your preferred account: ");
            var _option = Console.ReadLine();
            while (int.Parse(_option) < 0 || int.Parse(_option) > customer.Accounts.Count)
            {
                Console.WriteLine("Invalid option");
                Console.WriteLine("Choose your preferred account: ");
                _option = Console.ReadLine();
            }
            int accountOption = int.Parse(_option);
            return customer.Accounts[accountOption - 1];
        }

    }
}
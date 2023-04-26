using System;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Model
{
    public class MainMenu 
    {
        private static readonly IDb _database = new Db();
        private static readonly IMenu _Menu = new Menu();
        
        public static void StartApplication(DIContainer dIContainer)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("1: Login\n2: Open new User account\n3: Exit App");
            Console.WriteLine("***************************");
            string Option = Console.ReadLine();
            bool correct = Validation.Validate(Option);
            while (correct)
            {
                Console.WriteLine("Input correct option");
                Option = Console.ReadLine();
            }

            if (Option == "1")
            {
                Console.WriteLine("Enter password");
                string password = Console.ReadLine();
                Console.WriteLine("Enter email");
                string email = Console.ReadLine();
                Customer customer = new Customer();
                for (int i = 0; i < _database.Customers.Count; i++)
                {
                    if (PasswordGenerator.AreEqual(password, _database.Customers[i].PasswordHashed)
                        && _database.Customers[i].Email == email)
                    {
                        customer = _database.Customers[i];
                        break;
                    }
                }

                if (customer.Accounts.Count != 0)
                {
                    _Menu.MenuMethod(dIContainer, customer);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("User account not in Database");
                    StartApplication(dIContainer);
                }
            }
            else if (Option == "2")
            {
                RegisterUser.RegisterCustomer(dIContainer);
            }
            else if (Option == "3")
            {
                Environment.Exit(0);
            }
        }
    }
}
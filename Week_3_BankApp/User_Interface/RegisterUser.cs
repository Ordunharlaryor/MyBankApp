using System;
using System.Text.RegularExpressions;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp.Model
{
    public class RegisterUser
    {
        private  static readonly IMenu _Menu = new Menu();
        
        public static void RegisterCustomer(DIContainer dIContainer)
        {
            Console.Clear();
            Console.WriteLine("Enter Your First Name: (Firstname must not be empty, must not start with a digit and must not start with a small letter)");
            string firstName = Console.ReadLine();
            while (string.IsNullOrEmpty(firstName) || char.IsDigit(firstName[0]) || char.IsLower(firstName[0]))
            {
                Console.WriteLine($"{firstName} is not a valid firstName:\n Enter a valid firstName");
               // Console.WriteLine("Odun is stressing me");
                firstName = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("Enter Your Last Name: (Lastname must not be empty, must not start with a digit and must not start with a small letter)");
            string lastName = Console.ReadLine();
            while (string.IsNullOrEmpty(lastName) || char.IsDigit(lastName[0]) || char.IsLower(lastName[0]))
            {
                Console.WriteLine($"{lastName} is not a valid lastName:\n Enter a valid lastName");
                lastName = Console.ReadLine();
            }
            
            string FullName = firstName + " " + lastName;
            Console.WriteLine("Enter Your Email");
            string email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
            {
                Console.WriteLine($"{email} is not a valid email:\n Enter a valid email");
                //Console.WriteLine("Odun is stressing me");
                email = Console.ReadLine();
            }

            
            Console.WriteLine("Enter your password: (Password should contain numbers, special characters, at least one letter and should not be less than 6 characters)");
            string password = Console.ReadLine();
            bool isValid = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{6,}$");
            while (string.IsNullOrEmpty(password) && password.Length <= 6)
            {
                if(!isValid)
                Console.WriteLine("Invalid Input Detected! \n Ensure Your Password is not empty, \n  it contains at least a special character, \n it contains at least 6 or more characters ");
                password = Console.ReadLine();
            }

            Customer newCustomer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHashed = PasswordGenerator.GenerateHash(password)
            };

            dIContainer.CustomerRepo.Add(newCustomer);
            dIContainer.UserService.CreateAccount(newCustomer);
            _Menu.MenuMethod(dIContainer, newCustomer);
        }
    }
}
 
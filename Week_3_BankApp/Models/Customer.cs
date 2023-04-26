using System;
using System.Collections.Generic;
using Week_3_BankApp.Enum;

namespace Week_3_BankApp.Model
{
    public class Customer
    {
        public string CustomerId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public string Email { get; set; }
        //public string PhoneNumber { get; set; }
       // public string City { get; set; }
        //public string Country { get; set; }
        //public int Age { get; set; }
        public string PasswordHashed { get; set; }
        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}

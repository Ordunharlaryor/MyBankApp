using System;
using System.Collections.Generic;
using Week_3_BankApp.Enum;

namespace Week_3_BankApp.Model
{
    public class Account
    {
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
        public string AccountName { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string CustomerId { get; set; }
        public List<Statement> Statements { get; set; }

        /*public static implicit operator Account(bool v)
        {
            throw new NotImplementedException();
        }*/
    }
}
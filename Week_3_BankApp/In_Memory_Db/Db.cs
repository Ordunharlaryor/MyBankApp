using System.Collections.Generic;
using Week_3_BankApp.Model;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Abstraction.Interfaces;

namespace Week_3_BankApp.In_Memory_Db
{
    public class Db : IDb
    {
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Statement> Statements { get; set; } = new List<Statement>();
    }
}

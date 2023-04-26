using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Abstraction.Interfaces
{
    public interface IDb
    {
        List<Account> Accounts { get; set; }
        List<Customer> Customers { get; set; }
        List<Statement> Statements { get; set; }
    }
}

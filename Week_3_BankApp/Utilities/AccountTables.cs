using System;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Utilities
{
    public class AccountTables
    {
        public static class Account_Tables
        {
            public static void AccountDetails(Customer customer)
            {
                Console.WriteLine("ACCOUNT DETAILS");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "AMOUNT BALANCE");
                Console.WriteLine("--------------------------------------------------------------------------------------------");

                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", account.AccountName, account.AccountNumber, account.AccountType, account.Balance);
                }
            }

            public static void PrintStatement(Account account)
            {
                Console.WriteLine("ACCOUNT DETAILS");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", "DATE", "DESCRIPTION", "AMOUNT", "BALANCE");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                foreach (var statement in account.Statements)
                {
                    Console.WriteLine("|{0,20} | {1,20} | {2,20} | {3,20} | ", statement.StatementDate, statement.Description, statement.Amount, statement.AccountBalance);
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                }
            }
        }
    }
}

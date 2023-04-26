using System;
using System.Text;

namespace Week_3_BankApp.Utilities
{
    public class AccountGenerator
    {
        public static string GeneratorUniqueAccountNumber()
        {
            StringBuilder account_number = new StringBuilder("222", 10);
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                account_number.Append(random.Next(0, 9));
            }
            return account_number.ToString();
        }
    }
}

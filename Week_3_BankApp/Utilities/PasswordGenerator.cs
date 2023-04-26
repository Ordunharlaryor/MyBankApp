using System;
using System.Security.Cryptography;
using System.Text;

namespace Week_3_BankApp.Utilities
{
    public static class PasswordGenerator
    {
        // should be kept in a secret vault
        private static readonly string SALTVALUE = "jopr923974bhdafbeifb$";
        public static string GenerateHash(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + SALTVALUE);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool AreEqual(string plainTextInput, string hashedInput)
        {
            string newHashedPin = GenerateHash(plainTextInput);
            return newHashedPin.Equals(hashedInput);
        }
    }
}

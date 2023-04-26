namespace Week_3_BankApp.Utilities
{
    public static class Validation
    {
        public static bool Validate(string test)
        {
            bool isValid = false;
            if (string.IsNullOrWhiteSpace(test))
            {
                isValid = true;
            }
            if (int.Parse(test) == 1 || int.Parse(test) == 2)
            {
                isValid = false;
            }
            return isValid;

        }
    }
}

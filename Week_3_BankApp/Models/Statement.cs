using System;

namespace Week_3_BankApp.Model
{
    public class Statement
    {
        public string StatementId { get; set; } = Guid.NewGuid().ToString();
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime StatementDate { get; set; }
    }
}
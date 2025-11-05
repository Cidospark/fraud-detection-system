using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string SenderAccountNumber { get; set; } = "";
        public string ReceiverAccountNumber { get; set; } = "";
        public string TransactionType { get; set; } = "";
        public bool IsFlagged { get; set; }
        public string Status { get; set; } = "";
        public string Location { get; set; } = "";
        public string Device { get; set; } = "";
        public decimal Amount { get; set; }
        public int RiskScore { get; set; }
        public string Description { get; set; } = "";
        public string CreatedAt { get; set; } = "";

    }
}
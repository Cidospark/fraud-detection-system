using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class Alert
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public string Severity { get; set; } = "";
        public string Status { get; set; } = "";
        public string RuleReason { get; set; } = "";

        public string CreatedAt { get; set; } = "";

        public Transaction? Transaction { get; set; }

        public ICollection<CaseAlerts> CaseAlerts { get; set; } = [];
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class TriggeredRules
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TransactionId { get; set; }
        public Guid RuleId { get; set; }

        public Rule? Rule { get; set; }

        public Transaction? Transaction { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;

namespace FraudGuard.Application.Abstractions
{
    public class RiskResult
    {
        public int Score { get; set; }
        public Transaction? Transaction { get; set; }
        public Alert? Alert { get; set; }
        public List<TriggeredRules> TriggeredRules { get; set; } = [];
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class Case
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public Guid InvestigatorId { get; set; }
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString();
        public string UpdatedAt { get; set; } = DateTime.UtcNow.ToString();

        public ICollection<CaseAlerts> CaseAlerts { get; set; } = [];
        public User? Investigator { get; set; }
    }
}
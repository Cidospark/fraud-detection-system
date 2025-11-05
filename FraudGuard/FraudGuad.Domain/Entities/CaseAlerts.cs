using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Entities
{
    public class CaseAlerts
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CaseId { get; set; }
        public Guid AlertId { get; set; }

        public Case? Case { get; set; }

        public Alert? Alert { get; set; }

    }
}
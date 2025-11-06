using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Enums
{
    public enum CaseStatus
    {
        opened,
        under_investigation,
        closed,
        confirmed,
        fraud,
        false_positive
    }
}
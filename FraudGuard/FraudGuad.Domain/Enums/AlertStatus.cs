using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Enums
{
    public enum AlertStatus
    {
        pending,
        under_review,
        escalated,
        resolve
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudGuad.Domain.Enums
{
    public enum AlertStatus
    {
        pending,
        in_review,
        escalated,
        resolve
    }
}
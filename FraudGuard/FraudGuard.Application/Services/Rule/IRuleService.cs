using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;
using FraudGuard.Application.Abstractions;

namespace FraudGuard.Application.Services.Rule
{
    public interface IRuleService
    {
        Task<RiskResult> EvaluateRiskAsync(Transaction transaction);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;
using FraudGuad.Domain.Enums;
using FraudGuard.Application.Abstractions;
using FraudGuard.Application.Repository;

namespace FraudGuard.Application.Services.Rule
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepo;
        private readonly ITriggeredRule _triggeredRuleRepo;
        public RuleService(IRuleRepository ruleRepo, ITriggeredRule triggeredRuleRepo)
        {
            _ruleRepo = ruleRepo;
            _triggeredRuleRepo = triggeredRuleRepo;
        }
        
        private async Task TriggerAction(Transaction transaction, FraudGuad.Domain.Entities.Rule rule, RiskResult riskResult)
        {
            riskResult.Score += rule.Severity;
            var triggeredRule = new TriggeredRules
            {
                TransactionId = transaction.Id,
                RuleId = rule.Id
            };
            riskResult.TriggeredRules.Add(triggeredRule);
            await _triggeredRuleRepo.AddAsync(triggeredRule);

            var alert = new Alert
            {
                TransactionId = transaction.Id,
                Severity = Enum.GetName(typeof(AlertSeverity), rule.Severity) ?? "",
                RuleReason = rule.Name
            };
            riskResult.Alert = alert;
            // todo: raise alert notification here...
            // todo: add alert to db here...
        }

        public async Task<RiskResult> EvaluateRiskAsync(Transaction transaction)
        {
            var result = new RiskResult();
            var rules = await _ruleRepo.GetRulesAsync();
            
            // todo: this code still need some work... It needs to be implemented as a transaction to manage failure 
            // transaction will allow us commit and rollback
            try
            {
                #region todo: I will refactor this code later to use the strategy pattern
                foreach (var rule in rules)
                {
                    switch (rule.Field.ToLower())
                    {
                        case "amount":
                            if (transaction.Amount > Convert.ToInt32(rule.Value) && rule.Condition.Equals("greater than", StringComparison.CurrentCultureIgnoreCase))
                                await TriggerAction(transaction, rule, result);
                            break;

                        case "location":
                            if (transaction.Location != rule.Value && !rule.Condition.Equals("not equal", StringComparison.CurrentCultureIgnoreCase))
                                await TriggerAction(transaction, rule, result);
                            break;

                        case "status":
                            if (transaction.Location != rule.Value && !rule.Condition.Equals("not equal", StringComparison.CurrentCultureIgnoreCase))
                                await TriggerAction(transaction, rule, result);
                            break;
                    }
                }
                #endregion

                transaction.RiskScore = result.Score;
                result.Transaction = transaction;
                // todo: add transaction to db here...
            }
            catch
            {
                // rollback in case of fails
                throw;
            }

            return result;
        }
    }
}
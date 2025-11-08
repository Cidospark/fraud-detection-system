using FraudGuad.Domain.Entities;

namespace FraudGuard.Application.Repository
{
    public interface IRuleRepository
    {
        Task<IEnumerable<Rule>> GetRulesAsync();
    }
}
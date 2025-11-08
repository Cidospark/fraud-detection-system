using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;
using FraudGuard.Application.Repository;
using FraudGuard.Infrastructure.Abstractions;
using FraudGuard.Infrastructure.Data;

namespace FraudGuard.Infrastructure.Repository
{
    public class RuleRepository : UnitOfWork, IRuleRepository
    {
        private readonly FraudDbContext _context;
        public RuleRepository(FraudDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rule>> GetRulesAsync()
        {
            return await Task.FromResult(_context.Rules.AsEnumerable());
        }
    }
}
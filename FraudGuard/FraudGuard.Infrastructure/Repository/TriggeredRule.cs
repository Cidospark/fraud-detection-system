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
    public class TriggeredRule : UnitOfWork,ITriggeredRule
    {
        private readonly FraudDbContext _context;
        public TriggeredRule(FraudDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddAsync(TriggeredRules triggered)
        {
            await _context.AddAsync(triggered);
            await _context.SaveChangesAsync();
        }
    }
}
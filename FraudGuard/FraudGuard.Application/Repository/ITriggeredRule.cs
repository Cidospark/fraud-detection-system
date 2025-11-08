using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;

namespace FraudGuard.Application.Repository
{
    public interface ITriggeredRule
    {
        Task AddAsync(TriggeredRules triggered);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace FraudGuard.Infrastructure.Abstractions
{
    public abstract class UnitOfWork(FraudDbContext context)
    {
        public IDbContextTransaction BeginTransaction => context.Database.BeginTransaction();
    }
}
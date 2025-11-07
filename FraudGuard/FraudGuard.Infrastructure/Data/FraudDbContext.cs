using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;
using FraudGuard.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FraudGuard.Infrastructure.Data
{
    public class FraudDbContext : IdentityDbContext<ApplicationUser>
    {
        public FraudDbContext(DbContextOptions<FraudDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseAlerts> CaseAlerts { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TriggeredRules> TriggeredRules { get; set; }
    }
}
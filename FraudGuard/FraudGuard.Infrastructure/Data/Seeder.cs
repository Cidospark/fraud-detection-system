using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudGuad.Domain.Entities;
using FraudGuard.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FraudGuard.Infrastructure.Data
{
    public static class Seeder
    {
        public static async Task SeedMeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FraudDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Ensure database is created
            await context.Database.MigrateAsync();
            
            var roles = new string[] { "admin", "analyst", "viewer" };
            try
            {
                if (!roleManager.Roles.Any())
                {
                    foreach (var role in roles)
                    {
                        if (!await roleManager.RoleExistsAsync(role))
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                        }
                    }
                }

                if (!userManager.Users.Any())
                {
                    var userData = await File.ReadAllTextAsync("../FraudGuard.Infrastructure/Data/SeedData/users.json");
                    var users = JsonConvert.DeserializeObject<List<User>>(userData);
                    using var beginTransaction = await context.Database.BeginTransactionAsync();
                    try
                    {
                        foreach (var (user, index) in users.Select((value, i) => (value, i)))
                        {
                            user.UserName = user.Email;
                            var applicationUser = new ApplicationUser
                            {
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                PhotoUrl = user.PhotoUrl,
                                UserId = user.Id,
                                User = user
                            };
                            var result = await userManager.CreateAsync(applicationUser, "Password123!");
                            if (result.Succeeded)
                            {
                                if (index == 0)
                                {
                                    await userManager.AddToRoleAsync(applicationUser, "admin");
                                }
                                else if (index == 1)
                                {
                                    await userManager.AddToRoleAsync(applicationUser, "analyst");
                                }
                                else
                                {
                                    await userManager.AddToRoleAsync(applicationUser, "viewer");
                                }
                            }
                            else
                            {
                                throw new Exception($"Failed to create user {user.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                            }
                        }
                        await context.SaveChangesAsync();

                        await beginTransaction.CommitAsync();
                    }
                    catch
                    {
                        await beginTransaction.RollbackAsync();
                    }
                }

                if (!context.Rules.Any())
                {
                    var rulesData = await File.ReadAllTextAsync("../FraudGuard.Infrastructure/Data/SeedData/rules.json");
                    var rules = JsonConvert.DeserializeObject<List<Rule>>(rulesData);
                    if (rules != null && rules.Any())
                    {
                        await context.AddRangeAsync(rules);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Rules.Any())
                {
                    var transactionsData = await File.ReadAllTextAsync("../FraudGuard.Infrastructure/Data/SeedData/transactions.json");
                    var transactions = JsonConvert.DeserializeObject<List<Rule>>(transactionsData);
                    if (transactions != null && transactions.Any())
                    {
                        await context.AddRangeAsync(transactions);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Alerts.Any())
                {
                    var alertsData = await File.ReadAllTextAsync("../FraudGuard.Infrastructure/Data/SeedData/alerts.json");
                    var alerts = JsonConvert.DeserializeObject<List<Rule>>(alertsData);
                    if (alerts != null && alerts.Any())
                    {
                        await context.AddRangeAsync(alerts);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Cases.Any())
                {
                    var casesData = await File.ReadAllTextAsync("../FraudGuard.Infrastructure/Data/SeedData/cases.json");
                    var cases = JsonConvert.DeserializeObject<List<Rule>>(casesData);
                    if (cases != null && cases.Any())
                    {
                        await context.AddRangeAsync(cases);
                    }
                    await context.SaveChangesAsync();
                }
                
                
            }catch(Exception e)
            {
                Console.WriteLine($"Error seeding data - {e.Message}");
                throw;
            }
        }
    }
}
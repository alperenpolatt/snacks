using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core;
using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public static class SeedDatabase
    {
        public static async Task Seed(SnackJobsContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Roles.Count() == 0)
                {
                    context.Roles.AddRange(Roles);
                }
                await context.SaveChangesAsync();
            }
        }

        private static AppRole[] Roles = {
            new AppRole(){ Name=CustomRoles.Admin.ToString(),NormalizedName=CustomRoles.Admin.ToString().ToUpperInvariant()},
            new AppRole(){ Name=CustomRoles.Employer.ToString(),NormalizedName=CustomRoles.Employer.ToString().ToUpperInvariant()},
            new AppRole(){ Name=CustomRoles.Employee.ToString(),NormalizedName=CustomRoles.Employee.ToString().ToUpperInvariant()}
        };
       

    }
}

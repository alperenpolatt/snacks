using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SnackJobs.Api.Tiers.Data;
using SnackJobs.Api.Tiers.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Extensions
{
    public static class WebHostExtension
    {
        public  static IWebHost Seed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetService<SnackJobsContext>();

                    Task.Run(async () =>
                    {
                        await SeedDatabase.Seed(context);
                    }).Wait();
                }
                catch (Exception e)
                {
                    var ex = e.Message;
                }
                
            }
            return host;
        }
    }
}

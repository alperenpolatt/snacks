using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Core.Users;
using System;

namespace SnackJobs.Api.Tiers.Data
{
    public class SnackJobsContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SnackJobsContext(DbContextOptions<SnackJobsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoneApplication>()
                  .HasKey(dp => new
                  {
                      dp.GivenApplicationId,
                      dp.UserId
                  });


            modelBuilder.Entity<AppUser>()
                     .HasOne(a => a.Location)
                     .WithOne(a => a.User)
                     .HasForeignKey<Location>(c => c.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

        

            #region aspIdentity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().Ignore(x => x.TwoFactorEnabled);
            #endregion
        }

        public DbSet<GivenApplication> GivenApplications { get; set; }
        public DbSet<DoneApplication> DoneApplications { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}

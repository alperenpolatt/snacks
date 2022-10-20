using Microsoft.AspNetCore.Identity;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Core.EntitiesHelper;
using SnackJobs.Api.Tiers.Data;
using System;
using System.Collections.Generic;

namespace SnackJobs.Api.Tiers.Core.Users
{
    public class AppUser : IdentityUser<Guid>, ICreationDate
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
        public CustomRoles Role { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<GivenApplication> GivenApplications { get; set; }
        public virtual ICollection<DoneApplication> DoneApplications { get; set; }
        public virtual Location Location { get; set; }

    }
    public enum GenderType
    {
        Male,Female,Unspecified
    }
}

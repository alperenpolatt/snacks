using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Core
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual AppUser User { get; set; }
        public Guid UserId { get; set; } // Employer

        public string Title { get; set; }

        public double Lat { get; set; }
        public double Lon { get; set; }
        
    }
}

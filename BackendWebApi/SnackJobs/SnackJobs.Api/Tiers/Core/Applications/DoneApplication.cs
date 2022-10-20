using SnackJobs.Api.Tiers.Core.Users;
using System;

namespace SnackJobs.Api.Tiers.Core.Applications
{
    public class DoneApplication
    {
        public virtual AppUser User { get; set; }
        public Guid UserId { get; set; }

        public virtual GivenApplication GivenApplication { get; set; }
        public Guid GivenApplicationId { get; set; }

        public DoneApplicationType DoneApplicationType { get; set; }
        public float Vote { get; set; }  //By employers
        public string Comment { get; set; } //By employers
    }
    public enum DoneApplicationType
    {
        Pending,Denied,Accepted,Completed
    }
}

using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.User
{
    public class GeneralUserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
        public GeneralLocationResponse Location { get; set; }
    }
}

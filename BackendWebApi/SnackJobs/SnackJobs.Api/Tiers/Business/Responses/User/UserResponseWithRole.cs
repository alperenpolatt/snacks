using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.User
{
    public class UserResponseWithRole:GeneralUserResponse
    {
        public string RoleName { get; set; }
    }
}

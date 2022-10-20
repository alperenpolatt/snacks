using SnackJobs.Api.Tiers.Business.Responses.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.User
{
    public class EmployerUserDetailResponse:GeneralUserResponse
    {
        public virtual IEnumerable<GeneralGivenApplicationResponse> GivenApplications { get; set; }

    }
}

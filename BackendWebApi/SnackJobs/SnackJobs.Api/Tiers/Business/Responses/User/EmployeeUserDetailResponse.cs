using SnackJobs.Api.Tiers.Business.Responses.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.User
{
    public class EmployeeUserDetailResponse:GeneralUserResponse
    {
        public IEnumerable<GeneralDoneApplicationResponse> DoneApplications { get; set; }
    }
}

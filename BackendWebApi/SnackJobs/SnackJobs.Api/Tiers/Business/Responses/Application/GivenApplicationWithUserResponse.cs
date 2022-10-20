using SnackJobs.Api.Tiers.Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class GivenApplicationWithUserResponse:GeneralGivenApplicationResponse
    {
        public GeneralUserResponse User { get; set; }
    }
}

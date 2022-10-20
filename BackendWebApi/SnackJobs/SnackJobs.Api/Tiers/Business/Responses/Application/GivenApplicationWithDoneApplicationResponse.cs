using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class GivenApplicationWithDoneApplicationResponse:GeneralGivenApplicationResponse
    {
        public IEnumerable<GeneralDoneApplicationResponse> DoneApplications { get; set; }
    }
}

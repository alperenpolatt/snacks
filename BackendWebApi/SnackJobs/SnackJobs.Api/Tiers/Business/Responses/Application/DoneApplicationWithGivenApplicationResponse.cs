using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class DoneApplicationWithGivenApplicationResponse:GeneralDoneApplicationResponse
    {
        public GeneralGivenApplicationResponse GivenApplication { get; set; }
    }
}

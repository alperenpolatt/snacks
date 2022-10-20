using SnackJobs.Api.Tiers.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class GeneralDoneApplicationResponse
    {
        public Guid UserId { get; set; }
        public Guid GivenApplicationId { get; set; }

        public DoneApplicationType DoneApplicationType { get; set; }
        public float Vote { get; set; }  //By employers
        public string Comment { get; set; } //By employers
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses
{
    public class GeneralLocationResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.Application.Given
{
    public class ApplicationsByDistance
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double MaxDistance { get; set; }
        public string SearchTerm { get; set; }
    }
}

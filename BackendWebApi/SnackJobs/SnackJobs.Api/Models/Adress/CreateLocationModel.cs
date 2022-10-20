using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.Adress
{
    public class CreateLocationModel
    {
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}

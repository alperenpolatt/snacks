using SnackJobs.Api.Tiers.Core;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public class LocationDal : BaseRepository<Location>, ILocationDal
    {
        public LocationDal(SnackJobsContext context) : base(context)
        {
        }
    }
}

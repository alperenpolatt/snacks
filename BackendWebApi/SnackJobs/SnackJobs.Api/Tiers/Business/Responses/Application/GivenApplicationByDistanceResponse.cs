using SnackJobs.Api.Tiers.Business.Responses.User;
using SnackJobs.Api.Tiers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class GivenApplicationByDistanceResponse
    {
        public Guid Id { get; set; }
        public virtual GeneralUserResponse User { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TotalEmployee { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }

        public double DistanceBetweenApplicationAndMe { get; set; }
    }
}

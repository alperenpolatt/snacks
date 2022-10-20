using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.Application.Done
{
    public class AcceptApplicationModel
    {
        /// <summary>
        /// Due to done application is composite key...
        /// UserId : employee id
        /// </summary>
        public Guid GivenApplicationId { get; set; }
        public Guid UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.Application
{
    public class GeneralGivenApplicationResponse
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; } // Employer


        public string Name { get; set; }        
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TotalEmployee { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

    }
}

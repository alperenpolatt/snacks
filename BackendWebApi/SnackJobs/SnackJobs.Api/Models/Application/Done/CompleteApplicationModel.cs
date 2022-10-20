using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.Application.Done
{
    public class CompleteApplicationModel
    {
        public Guid GivenApplicationId { get; set; }
        public Guid UserId { get; set; }
        [Range(0,5)]
        public float Vote { get; set; }  
        public string Comment { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.Application.Given
{
    public class RegisterApplicationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        [Required]
        public int TotalEmployee { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}

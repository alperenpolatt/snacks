using SnackJobs.Api.Tiers.Core.EntitiesHelper;
using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Core.Applications
{
    public class GivenApplication: ICreationDate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
        public Guid? UserId { get; set; } // Employer

        

        public string Name { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int TotalEmployee { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<DoneApplication> DoneApplications { get; set; }
    }
}

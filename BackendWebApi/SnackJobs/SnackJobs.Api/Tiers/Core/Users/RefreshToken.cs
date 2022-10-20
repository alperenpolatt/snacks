using SnackJobs.Api.Tiers.Core.EntitiesHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SnackJobs.Api.Tiers.Core.Users
{
    public class RefreshToken:ICreationDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Token { get; set; }

        public string JwtId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public bool Used { get; set; }

        public bool Invalidated { get; set; }

        public virtual AppUser User { get; set; }
        public Guid UserId { get; set; }

    }
}

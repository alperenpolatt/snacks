using SnackJobs.Api.Tiers.Core.Users;
using SnackJobs.Api.Tiers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.User
{
    public class RegisterUserModel
    {
        [Required]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public virtual string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public GenderType GenderType { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public RegistarableRole Role { get; set; }
    }
    public enum RegistarableRole
    {
         Employer=1, Employee=2
    }
}

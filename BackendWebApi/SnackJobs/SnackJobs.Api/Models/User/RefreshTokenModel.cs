using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Models.User
{
    public class RefreshTokenModel
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}

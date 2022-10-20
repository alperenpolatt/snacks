using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Responses.User
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public int AccessTokenExpiration { get=> JwtSettings.AccessTokenExpiration; }  

        public int RefreshTokenExpiration { get => JwtSettings.RefreshTokenExpiration; }
    }
}

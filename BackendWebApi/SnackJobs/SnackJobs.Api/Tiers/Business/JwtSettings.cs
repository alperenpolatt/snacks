using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business
{
    public static class JwtSettings
    {
        public const string Audience = "http://localhost:57859";
        public const string Issuer = "http://localhost:57859";
        public const int AccessTokenExpiration = 10080;
        public const int RefreshTokenExpiration = 10080;
        public const string SecurityKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH";
    }
}

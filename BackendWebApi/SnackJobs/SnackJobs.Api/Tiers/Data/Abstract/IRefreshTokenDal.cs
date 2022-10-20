using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Abstract
{
    public interface IRefreshTokenDal : IRepository<RefreshToken>
    {
        Task<RefreshToken> SingleAsync(string refreshToken);
    }
}

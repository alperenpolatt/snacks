using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core.Users;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public class RefreshTokenDal : BaseRepository<RefreshToken>, IRefreshTokenDal
    {
        public RefreshTokenDal(SnackJobsContext context) : base(context)
        {
        }

        public async Task<RefreshToken> SingleAsync(string refreshToken)
        {
            return await _context.RefreshTokens.SingleOrDefaultAsync(a => a.Token == refreshToken);
        }
    }
}

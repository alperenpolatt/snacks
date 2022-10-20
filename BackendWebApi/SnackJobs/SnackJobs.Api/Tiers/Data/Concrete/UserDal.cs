using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core.Users;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public class UserDal : BaseRepository<AppUser>, IUserDal
    {
        public UserDal(SnackJobsContext context) : base(context)
        {
        }

    

        public async Task<AppUser> GetByUserIdWithAllAsync(Guid userId)
        {
            return await _context.Users.Where(x => x.Id == userId)
                                .Include(x => x.DoneApplications)
                                .ThenInclude(y=>y.GivenApplication)
                                .Include(x => x.Location)
                                .Include(x=>x.GivenApplications)
                                .ThenInclude(y=>y.DoneApplications)
                                .FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetByUserIdWithDoneApplicationAsync(Guid userId)
        {
            return await _context.Users.Where(x => x.Id == userId)
                                   .Include(x => x.DoneApplications)
                                   .Include(x=>x.Location)
                                   .FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetByUserIdWithGivenApplicationAsync(Guid userId)
        {
            return await _context.Users.Where(x => x.Id == userId)
                                  .Include(x => x.GivenApplications)
                                  .Include(x => x.Location)
                                  .FirstOrDefaultAsync();
        }
    }
}

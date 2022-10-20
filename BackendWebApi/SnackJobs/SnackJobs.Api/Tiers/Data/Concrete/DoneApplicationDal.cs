using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public class DoneApplicationDal : BaseRepository<DoneApplication>, IDoneApplicationDal
    {
        public DoneApplicationDal(SnackJobsContext context) : base(context)
        {
        }

        public async Task<DoneApplication> GetByCompositeKeys(Guid userId, Guid givenApplicationId)
        {
            var entity = await _context.DoneApplications
                               .SingleOrDefaultAsync(x=>x.UserId == userId && x.GivenApplicationId==givenApplicationId);

            return entity;
        }

        public async Task<IEnumerable<DoneApplication>> GetByGivenAppIdWithUserAsync(Guid givenAppId)
        {
            return await _context.DoneApplications
                        .Where(dp => dp.GivenApplicationId == givenAppId)
                        .Include(x=>x.User)
                        .ToListAsync();
        }

        public async Task<IEnumerable<DoneApplication>> GetByUserIdWithGivenApplicationAsync(Guid userId)
        {
            return await _context.DoneApplications
                         .Where(dp => dp.UserId == userId)
                         .Include(dp => dp.GivenApplication)
                         .ToListAsync();
        }

        public async Task<DoneApplication> UpdateAsync(DoneApplication entity)
        {
            if (entity == null)
                return null;
            DoneApplication exist = await _context.DoneApplications
                    .SingleOrDefaultAsync(dp => dp.UserId == entity.UserId &&
                    dp.GivenApplicationId == entity.GivenApplicationId);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
            }

            return exist;
        }
    }
}

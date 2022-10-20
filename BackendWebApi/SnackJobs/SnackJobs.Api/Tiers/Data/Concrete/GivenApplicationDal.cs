using Microsoft.EntityFrameworkCore;
using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Concrete
{
    public class GivenApplicationDal : BaseRepository<GivenApplication>, IGivenApplicationDal
    {
        public GivenApplicationDal(SnackJobsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GivenApplication>> GetAllWithLocationAsync()
        {
            return await _context.GivenApplications
                                    .Where(x=>x.IsActive)
                                   .Include(x => x.User)
                                   .ThenInclude(y=>y.Location)
                                   .ToListAsync();
        }

        public async Task<GivenApplication> GetByIdWithUserAndLocationAsync(Guid id)
        {
            return await _context.GivenApplications.Where(x => x.Id == id)
                                                    .Include(x => x.User)
                                                    .ThenInclude(y => y.Location)
                                                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GivenApplication>> GetBySearchTermWithLocationAsync(string searchTerm)
        {
            return await _context.GivenApplications
                                    .Where(x => x.IsActive && x.Name.Contains(searchTerm) ||                                          x.Title.Contains(searchTerm))
                                   .Include(x => x.User)
                                   .ThenInclude(y => y.Location)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<GivenApplication>> GetByUserIdWithDoneApplicationsAsync(Guid userId)
        {
            return await _context.GivenApplications.Where(x => x.UserId == userId)
                                             .Include(x => x.DoneApplications)
                                             .ToListAsync();
        }
    }
}

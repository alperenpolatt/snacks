using SnackJobs.Api.Tiers.Core.Applications;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Abstract
{
    public interface IGivenApplicationDal: IRepository<GivenApplication>
    {
        Task<IEnumerable<GivenApplication>> GetByUserIdWithDoneApplicationsAsync(Guid userId);
        Task<GivenApplication> GetByIdWithUserAndLocationAsync(Guid id);
        Task<IEnumerable<GivenApplication>> GetAllWithLocationAsync();
        Task<IEnumerable<GivenApplication>> GetBySearchTermWithLocationAsync(string searchTerm);
    }
}

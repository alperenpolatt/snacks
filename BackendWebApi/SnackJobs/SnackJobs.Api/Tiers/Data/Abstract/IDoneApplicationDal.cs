using SnackJobs.Api.Tiers.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Abstract
{
    public interface IDoneApplicationDal : IRepository<DoneApplication>
    {
        Task<DoneApplication> GetByCompositeKeys(Guid userId, Guid givenApplicationId);
        Task<DoneApplication> UpdateAsync(DoneApplication entity);
        Task<IEnumerable<DoneApplication>> GetByUserIdWithGivenApplicationAsync(Guid userId);
        Task<IEnumerable<DoneApplication>> GetByGivenAppIdWithUserAsync(Guid givenAppId);
    }
}

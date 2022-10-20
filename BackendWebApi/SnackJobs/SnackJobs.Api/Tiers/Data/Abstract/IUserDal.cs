using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Data.Abstract
{
    public interface IUserDal: IRepository<AppUser>
    {
        Task<AppUser> GetByUserIdWithGivenApplicationAsync(Guid userId);
        Task<AppUser> GetByUserIdWithDoneApplicationAsync(Guid userId);
        Task<AppUser> GetByUserIdWithAllAsync(Guid userId);
    }
}

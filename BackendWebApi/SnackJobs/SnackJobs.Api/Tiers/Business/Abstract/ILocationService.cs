using SnackJobs.Api.Models.Adress;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Abstract
{
    public interface ILocationService
    {
        Task<BasexResponse<Core.Location>> CreateAsync(Core.Location location);
        Task<BasexResponse<GeneralLocationResponse>> GetByUserIdAsync(Guid userId);
    }
}

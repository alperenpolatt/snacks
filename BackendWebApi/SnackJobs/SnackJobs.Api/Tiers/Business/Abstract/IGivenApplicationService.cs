using SnackJobs.Api.Models.Application;
using SnackJobs.Api.Models.Application.Given;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.Application;
using SnackJobs.Api.Tiers.Core.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Abstract
{
    public interface IGivenApplicationService
    {
        Task<BasexResponse<GivenApplication>> RegisterApplicationAsync(GivenApplication givenApplication);
        Task<BasexResponse<IEnumerable<GivenApplicationWithDoneApplicationResponse>>> GetApplications(Guid userId);
        Task<BasexResponse<IEnumerable<DoneApplicationWithUserResponse>> > GetApplicationWithDoneAppsDetail(Guid givenApplicationId);
        Task<BasexResponse<GivenApplicationWithUserResponse>> GetPublicGivenApplicationDetailAsync(Guid id);
        Task<BasexResponse<IEnumerable<GivenApplicationByDistanceResponse>>> GetApplicationsByDistance(ApplicationsByDistance model);
    }
}

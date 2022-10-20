using SnackJobs.Api.Models.Application.Done;
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
    public interface IDoneApplicationService
    {
        Task<BasexResponse<DoneApplication>> MakeApplicationAsync(DoneApplication doneApplication);
        Task<BasexResponse<DoneApplication>> DenyApplicationAsync(DoneApplication doneApplication);
        Task<BasexResponse<DoneApplication>> AcceptApplicationAsync(DoneApplication doneApplication);
        Task<BasexResponse<DoneApplication>> CompleteApplicationAsync(DoneApplication doneApplication);
        Task<BasexResponse<IEnumerable<DoneApplicationWithGivenApplicationResponse>>> GetApplicationsAsync(Guid userId);
    }
}

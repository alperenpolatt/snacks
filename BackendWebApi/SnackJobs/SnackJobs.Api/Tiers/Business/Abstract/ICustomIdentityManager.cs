using SnackJobs.Api.Models.User;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.User;
using SnackJobs.Api.Tiers.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Abstract
{
    public interface ICustomIdentityManager
    {
        Task<BasexResponse<GeneralUserResponse>> RegisterAsync(RegisterUserModel user);//only student
        Task<BaseResponse> ConfirmUserAsync(Guid userId, string token);
        Task<string> GenerateEmailConfirmationTokenAsync(AppUser user);
        Task<BasexResponse<AuthenticationResponse>> LoginAsync(string email, string password);
        Task<BasexResponse<AuthenticationResponse>> RefreshTokenAsync(string token, string refreshToken);

    }
}

using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Abstract
{
    public interface IUserService
    {
        Task<BasexResponse<UserResponseWithRole>> GetUserByEmailWithRoleAsync(string email);
        Task<BasexResponse<IEnumerable<UserResponseWithRole>>> GetAllUsersWithRoleAsync();
        Task<BasexResponse<GeneralUserResponse>> DeleteUserAsync(Guid userId);
        Task<BasexResponse<PublicProfileResponse>> GetPublicProfileByIdAsync(Guid externalUserId);
        Task<BasexResponse<EmployeeUserDetailResponse>> GetEmployeeUserByIdWithRoleAsync(Guid userId);
        Task<BasexResponse<EmployerUserDetailResponse>> GetEmployerUserByIdWithRoleAsync(Guid userId);
    }
}

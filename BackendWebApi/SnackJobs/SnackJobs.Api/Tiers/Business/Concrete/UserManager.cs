using Mapster;
using Microsoft.AspNetCore.Identity;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Business.Responses;
using SnackJobs.Api.Tiers.Business.Responses.User;
using SnackJobs.Api.Tiers.Core.Users;
using SnackJobs.Api.Tiers.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackJobs.Api.Tiers.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<AppUser> _aspUserManager;
        private RoleManager<AppRole> _aspRoleManager;
        private IUserDal _userDal;
        public UserManager(IUnitOfWork unitOfWork, UserManager<AppUser> aspUserManager, RoleManager<AppRole> aspRoleManager, IUserDal userDal)
        {
            _unitOfWork = unitOfWork;
            _aspUserManager = aspUserManager;
            _aspRoleManager = aspRoleManager;
            _userDal = userDal;
        }

        public async Task<BasexResponse<GeneralUserResponse>> DeleteUserAsync(Guid userId)
        {
            try
            {
                var user =await _aspUserManager.FindByIdAsync(userId.ToString());
                await _aspUserManager.DeleteAsync(user);
                await _unitOfWork.CompleteAsync();
                return new BasexResponse<GeneralUserResponse>(user.Adapt<GeneralUserResponse>());
            }
            catch (Exception ex)
            {
                return new BasexResponse<GeneralUserResponse>(ex.Message);
            }
        }

        public async Task<BasexResponse<IEnumerable<UserResponseWithRole>>> GetAllUsersWithRoleAsync()
        {
            try
            {
                var response = await _userDal.GetAllAsync();
                var usersResponseWithRole = new List<UserResponseWithRole>();
                var userResponseWithRole = new UserResponseWithRole();
                foreach (var item in response)
                {
                    userResponseWithRole = item.Adapt<UserResponseWithRole>();
                    var role = await _aspUserManager.GetRolesAsync(item);
                    userResponseWithRole.RoleName = role.FirstOrDefault();
                    usersResponseWithRole.Add(userResponseWithRole);
                }
                return new BasexResponse<IEnumerable<UserResponseWithRole>>(usersResponseWithRole);
            }
            catch (Exception ex)
            {
                return new BasexResponse<IEnumerable<UserResponseWithRole>>(ex.Message);
            }
        }

        public async Task<BasexResponse<EmployeeUserDetailResponse>> GetEmployeeUserByIdWithRoleAsync(Guid userId)
        {
            try
            {
                var response = await _userDal.GetByUserIdWithDoneApplicationAsync(userId);
                return new BasexResponse<EmployeeUserDetailResponse>(response.Adapt<EmployeeUserDetailResponse>());
            }
            catch (Exception ex)
            {
                return new BasexResponse<EmployeeUserDetailResponse>(ex.Message);
            }
        }

        public async Task<BasexResponse<EmployerUserDetailResponse>> GetEmployerUserByIdWithRoleAsync(Guid userId)
        {
            try
            {
                var response = await _userDal.GetByUserIdWithGivenApplicationAsync(userId);
                return new BasexResponse<EmployerUserDetailResponse>(response.Adapt<EmployerUserDetailResponse>());
            }
            catch (Exception ex)
            {
                return new BasexResponse<EmployerUserDetailResponse>(ex.Message);
            }
        }

        public async Task<BasexResponse<PublicProfileResponse>> GetPublicProfileByIdAsync(Guid externalUserId)
        {
            try
            {
                var response = await _userDal.GetByUserIdWithAllAsync(externalUserId);
                var roleNames = await _aspUserManager.GetRolesAsync(response);

                var adapted = response.Adapt<PublicProfileResponse>();
                adapted.RoleName = roleNames.FirstOrDefault();
                
                return new BasexResponse<PublicProfileResponse>(adapted);
            }
            catch (Exception ex)
            {

                return new BasexResponse<PublicProfileResponse>(ex.Message);
            }
        }

        public async Task<BasexResponse<UserResponseWithRole>> GetUserByEmailWithRoleAsync(string email)
        {
            var user = await _aspUserManager.FindByEmailAsync(email);
            if (user == null)
                return new BasexResponse<UserResponseWithRole>("There is no user with this email ");
            var role = await _aspUserManager.GetRolesAsync(user);

            var userWithRole = user.Adapt<UserResponseWithRole>();
            userWithRole.RoleName = role.FirstOrDefault();
            return new BasexResponse<UserResponseWithRole>(userWithRole);

        }
    }
}

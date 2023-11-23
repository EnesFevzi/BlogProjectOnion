using BlogProjectOnion.Application.DTOs.AppUserDto;
using BlogProjectOnion.Application.Services.Abstract;
using BlogProjectOnion.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Concrete
{
    public class UserService : IUserService
    {
        public Task<IdentityResult> CreateUserAsync(CreateUserDto userAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppRole>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppRole>> GetRolesWithoutSuperadminAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileDto> GetUserProfileAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserProfileAsyncWitRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserRoleAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetUsersWithoutSuperadminRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetUsersWithUserRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetWorkersWithUserRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            throw new NotImplementedException();
        }
    }
}

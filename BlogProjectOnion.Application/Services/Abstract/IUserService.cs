using BlogProjectOnion.Application.DTOs.AppUserDto;
using BlogProjectOnion.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectOnion.Application.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersWithRoleAsync();
        Task<List<UserDto>> GetUsersWithUserRoleAsync();
        Task<List<UserDto>> GetWorkersWithUserRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<AppUser> GetUserAsync();
        Task<List<UserDto>> GetUsersWithoutSuperadminRoleAsync();
        Task<List<AppRole>> GetRolesWithoutSuperadminAsync();
        Task<IdentityResult> CreateUserAsync(CreateUserDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDto> GetUserProfileAsync();
        Task<UserDto> GetUserProfileAsyncWitRoleAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto);
       // Task<WeatherInfo> GetWeatherInfo();
    }
}

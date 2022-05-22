using System;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Entities;
using Authentication.ViewDto;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Contract
{
    public interface IUserOperation
    {
        Task<IdentityResult> CreateAsync(RegisterUserDto user);
        Task<SignInResult> LoginAsync(LoginDto login);
        Task<bool> DeleteAsync(string id);
        AppUser FindById(string id);
        Task<AppUser> FindByNameAsync(string normalizedUserName);
        Task<string> GetNormalizedUserNameAsync(AppUser user);
        Task<string> GetUserIdAsync(AppUser user);
        Task<string> GetUserNameAsync(AppUser user);
        Task SetUserNameAsync(AppUser user, string userName);
        Task<IdentityResult> UpdateAsync(AppUser user);
        Task SetNormalizedUserNameAsync(AppUser user, string normalizedName);
        Task<string> GetPasswordHashAsync(AppUser user);
        Task<bool> HasPasswordAsync(AppUser user);
        Task SetPasswordHashAsync(AppUser user, string passwordHash);
    }
}

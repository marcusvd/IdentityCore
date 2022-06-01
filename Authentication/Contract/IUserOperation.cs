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
        Task<bool> DeleteAsync(int id);
        User FindById(int id);
        Task<User> FindByNameAsync(string normalizedUserName);
        Task<string> GetNormalizedUserNameAsync(User user);
        Task<string> GetUserIdAsync(User user);
        Task<string> GetUserNameAsync(User user);
        Task SetUserNameAsync(User user, string userName);
        Task<IdentityResult> UpdateAsync(User user);
        Task SetNormalizedUserNameAsync(User user, string normalizedName);
        Task<string> GetPasswordHashAsync(User user);
        Task<bool> HasPasswordAsync(User user);
        Task SetPasswordHashAsync(User user, string passwordHash);
    }
}

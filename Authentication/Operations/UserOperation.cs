using System.Threading;
using System.Threading.Tasks;
using Authentication.Entities;
using Authentication.Contract;
using Microsoft.AspNetCore.Identity;
using Authentication.ViewDto;
using System.Linq;
using System;
using AutoMapper;

namespace Authentication.Operations
{
    public class UserOperation : IUserOperation
    {

        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _SignInManager;
        private readonly IMapper _Map;

        public UserOperation(
            UserManager<AppUser> Usermanager,
            SignInManager<AppUser> Signinmanager,
            IMapper Map
            )
        {
            _UserManager = Usermanager;
            _SignInManager = Signinmanager;
            _Map = Map;
        }


        public async Task<IdentityResult> CreateAsync(RegisterUserDto user)
        {
            try
            {
                var userNew = await _UserManager.FindByNameAsync(user.UserName);

                if (userNew == null)
                {
                    userNew = new AppUser()
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FullName = user.FullName,
                    };
                    var result = await _UserManager.CreateAsync(userNew, user.Password);

                    if (result.Succeeded)

                    {
                        var fromDb = _UserManager.Users.FirstOrDefault(usrName =>
                         usrName.NormalizedUserName == userNew.UserName.ToUpper()
                         );
                        return result;
                    }
                }

                throw new Exception("Unauthorized, user already exist, try another name.");

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro service layer, {ex.Message}");
            }
        }

        public async Task<SignInResult> LoginAsync(LoginDto login)
        {
            try
            {
                if (login == null) throw new Exception("entity login is null");

                var user = await _UserManager.FindByNameAsync(login.UserName);

                SignInResult authResult = await _SignInManager.CheckPasswordSignInAsync(user, login.Password, false);

                if (authResult.Succeeded)
                {

                    return authResult;
                }

                return authResult;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro, app layer. {ex.Message}");
            }


        }
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                if (id == null) throw new Exception("id is 0");

                var user = _UserManager.Users.FirstOrDefault(_id => _id.Id == id);

                if (user != null)
                {
                    var delete = await _UserManager.DeleteAsync(user);

                    if (delete.Succeeded)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AppUser FindById(string id)
        {
             try
            {
                if (id == null) throw new Exception("id is 0");

                var user = _UserManager.Users.FirstOrDefault(_id => _id.Id == id);

                if (user != null)
                {
                        return user;
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AppUser> FindByNameAsync(string normalizedUserName)
        {
            var user = await _UserManager.FindByNameAsync(normalizedUserName);

            return user;
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(AppUser user, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
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

        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly IMapper _Map;

        public UserOperation(
            UserManager<User> Usermanager,
            SignInManager<User> Signinmanager,
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
                    userNew = new User()
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
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception("id is 0");

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

        public User FindById(int id)
        {
             try
            {
                if (id == 0) throw new Exception("id is 0");

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

        public async Task<User> FindByNameAsync(string normalizedUserName)
        {
            var user = await _UserManager.FindByNameAsync(normalizedUserName);

            return user;
        }

        public Task<string> GetNormalizedUserNameAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
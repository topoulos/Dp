using System;
using System.Threading.Tasks;
using Dp.Api.Models;
using DP.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Data
{
    public class AuthRepository : IDisposable
    {
        private readonly DpContext _ctx;
        private readonly ApplicationUserManager _userManager;

        public AuthRepository()
        {
            _ctx = new DpContext();
            _userManager = new ApplicationUserManager(new UserStore(_ctx));
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

        public async Task<User> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }
    }
}
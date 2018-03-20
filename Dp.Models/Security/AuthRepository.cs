using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Dp.Models.Security
{
    public class AuthRepository : IDisposable
    {
        private readonly DpContext _ctx;
        private readonly DpUserManager _userManager;

        public AuthRepository()
        {
            _ctx = new DpContext();
            _userManager = new DpUserManager(new DpUserStore(_ctx));
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
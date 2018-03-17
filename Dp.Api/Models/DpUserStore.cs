using Dp.Api.Data;
using DP.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class DpUserStore : UserStore<User, Role, int,
        UserLogin, UserRole, UserClaim>
    {
        public DpUserStore(DpContext context)
            : base(context)
        {
        }
    }
}
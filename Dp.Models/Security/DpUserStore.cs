using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Models.Security
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
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Models.Security
{
    public class DpRoleStore : RoleStore<Role, int, UserRole>
    {
        public DpRoleStore(DpContext context)
            : base(context)
        {
        }
    }
}
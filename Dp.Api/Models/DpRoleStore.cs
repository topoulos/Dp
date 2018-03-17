using Dp.Api.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class DpRoleStore : RoleStore<Role, int, UserRole>
    {
        public DpRoleStore(DpContext context)
            : base(context)
        {
        }
    }
}
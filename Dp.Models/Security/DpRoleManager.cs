using Microsoft.AspNet.Identity;

namespace Dp.Models.Security
{
    public class DpRoleManager : RoleManager<Role, int>
    {
        public DpRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}
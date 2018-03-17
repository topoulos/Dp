using Dp.Api.Models;
using Microsoft.AspNet.Identity;

namespace Dp.Api.Data
{
    public class DpRoleManager : RoleManager<Role, int>
    {
        public DpRoleManager(IRoleStore<Role, int> store) : base(store)
        {
        }
    }
}
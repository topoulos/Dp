using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}
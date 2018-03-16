using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dp.Api.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(DpContext context)
            : base(context)
        {
        }
    }
}
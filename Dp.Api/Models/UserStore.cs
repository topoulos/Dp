using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dp.Api.Data;
using DP.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class UserStore : UserStore<User, Role, int,
        UserLogin, UserRole, UserClaim>
    {
        public UserStore(DpContext context)
            : base(context)
        {
        }
    }
}
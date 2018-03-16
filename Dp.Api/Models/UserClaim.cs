using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Models
{
    public class UserClaim: IdentityUserClaim<int>
    {
    }
}
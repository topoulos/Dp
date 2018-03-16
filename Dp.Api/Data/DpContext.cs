using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Dp.Api.Models;
using DP.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Api.Data
{
    public class DpContext : IdentityDbContext<User, Role,
        int, UserLogin, UserRole, UserClaim>
    {
        public DbSet<DpProject> DpProjects { get; set; }
        public DbSet<DpTask> DpTasks { get; set; }

        public DpContext()
            : base("DpContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DpProject>().ToTable("DpProjects");
            modelBuilder.Entity<DpTask>().ToTable("DpTasks");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<Role>().ToTable("Roles");
        }
    }
}
using System.Data.Entity;
using Dp.Models.Database;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dp.Models.Security
{
    public class DpContext : IdentityDbContext<User, Role,
        int, UserLogin, UserRole, UserClaim>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        public DpContext()
            : base("DpContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<TaskItem>().ToTable("TaskItems");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<Role>().ToTable("Roles");
        }
    }
}
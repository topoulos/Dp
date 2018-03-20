using System;
using System.Linq;
using Dp.Models.Database;
using Microsoft.AspNet.Identity;

namespace Dp.Models.Security
{
    public static class DbInitializer
    {
        public static void Initialize(DpContext context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new DpRoleStore(context);
                var manager = new DpRoleManager(store);
                var role = new Role() { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "founder"))
            {
                var store = new DpUserStore(context);
                var manager = new DpUserManager(store);
                var user = new User { UserName = "founder" };

                manager.Create(user, "Password1!");
                manager.AddToRole(user.Id, "AppAdmin");
            }
            // Look for any students.
            if (context.Projects.Any())
            {
                return;   // DB has been seeded
            }

            context.Projects.Add(
                new Project
                {
                    Name = "Project 1",
                    Description = "Project 1 Description",
                    CreatedDateTime = DateTime.Parse("2000-01-01"),
                    TaskItems =  new[]
                    {
                        new TaskItem{Name="Task1", Description= "Task 1 Description",CreatedDateTime= DateTime.Parse("2005-09-01"),IsActive = true, ProjectId = 1},
                        new TaskItem{Name="Task2", Description= "Task 2 Description",CreatedDateTime= DateTime.Parse("2015-11-15"),IsActive = true, ProjectId = 1},
                        new TaskItem{Name="Task3", Description= "Task 3 Description",CreatedDateTime= DateTime.Parse("2016-09-12"),IsActive = true, ProjectId = 1},
                        new TaskItem{Name="Task4", Description= "Task 4 Description",CreatedDateTime= DateTime.Parse("2004-01-12"),IsActive = true, ProjectId = 1}
                    }
                });

            context.SaveChanges();


        }
    }
}
using System;
using System.Linq;
using Dp.Api.Data;
using DP.Api.Models;

namespace DP.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DpContext context)
        {

            // Look for any students.
            if (context.DpProjects.Any())
            {
                return;   // DB has been seeded
            }

            context.DpProjects.Add(
                new DpProject
                {
                    Name = "Project 1",
                    Description = "Project 1 Description",
                    CreatedDateTime = DateTime.Parse("2000-01-01"),
                    DpTasks =  new[]
                    {
                        new DpTask{Name="Task1", Description= "Task 1 Description",CreatedDateTime= DateTime.Parse("2005-09-01"),IsActive = true, DpProjectId = 1},
                        new DpTask{Name="Task2", Description= "Task 2 Description",CreatedDateTime= DateTime.Parse("2015-11-15"),IsActive = true, DpProjectId = 1},
                        new DpTask{Name="Task3", Description= "Task 3 Description",CreatedDateTime= DateTime.Parse("2016-09-12"),IsActive = true, DpProjectId = 1},
                        new DpTask{Name="Task4", Description= "Task 4 Description",CreatedDateTime= DateTime.Parse("2004-01-12"),IsActive = true, DpProjectId = 1}
                    }
                });

            context.SaveChanges();


        }
    }
}
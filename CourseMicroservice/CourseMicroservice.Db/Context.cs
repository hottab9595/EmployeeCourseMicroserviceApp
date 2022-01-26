using System.Collections.Generic;
using CourseMicroservice.Db.Interfaces;
using CourseMicroservice.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseMicroservice.Db
{
    public class Context : DbContext, IContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEmployee> CourseEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new Course
                {
                    Id = 1,
                    Signature = ".NET",
                    Duration = 6,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 2,
                    Signature = "Java",
                    Duration = 6,
                    IsDeleted = false
                },
                new Course
                {
                    Id = 3,
                    Signature = "SQL",
                    Duration = 1,
                    IsDeleted = false
                },
            });

            modelBuilder.Entity<CourseEmployee>().HasData(new List<CourseEmployee>
            {
                new CourseEmployee
                {
                    Id = 1,
                    CourseId = 1,
                    EmployeeId = 1
                },
                new CourseEmployee
                {
                    Id = 2,
                    CourseId = 1,
                    EmployeeId = 2
                },
            });
        }
    }
}
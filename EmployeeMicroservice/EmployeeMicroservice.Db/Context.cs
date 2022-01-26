using EmployeeMicroservice.Db.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmployeeMicroservice.Db.Models;

namespace EmployeeMicroservice.Db
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
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Signature = "Developers",
                    IsDeleted = false,
                    ParentId = null
                },
                new Department
                {
                    Id = 2,
                    Signature = "Administration",
                    IsDeleted = false,
                    ParentId = null
                },
                new Department
                {
                    Id = 3,
                    Signature = "HR department",
                    IsDeleted = false,
                    ParentId = 1
                }
            });

            modelBuilder.Entity<Employee>().HasData(new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Surname = "Koshel",
                    Name = "Egor",
                    Patronymic = "Viktotovich",
                    IsDeleted = false,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    Surname = "TestSurname",
                    Name = "TestName",
                    Patronymic = "TestPatronymic",
                    IsDeleted = false,
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 3,
                    Surname = "TestSurname1",
                    Name = "TestName1",
                    Patronymic = "TestPatronymic1",
                    IsDeleted = false,
                    DepartmentId = 3
                }
            });
        }
    }
}
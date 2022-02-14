using System;
using System.Collections.Generic;
using System.Linq;
using AuthorizationMicroservice.Db.Interfaces;
using AuthorizationMicroservice.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Db
{
    public class Context : DbContext, IContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dictionary<string, Role> roles = new Dictionary<string, Role>
            {
                {"Admin", new Role { Id = Guid.NewGuid(), Name = "Admin" }},
                {"Guest", new Role { Id = Guid.NewGuid(), Name = "Guest" }}
            };

            Dictionary<string, User> users = new Dictionary<string, User>
            {
                {"Admin", new User{Id = Guid.NewGuid(), Login = "admin", Password = "admin"}},
                {"Guest", new User{Id = Guid.NewGuid(), Login = "guest", Password = "guest"}}
            };

            modelBuilder.Entity<Role>().HasData(new List<Role>(roles.Values));

            modelBuilder.Entity<User>().HasData(new List<User>(users.Values));
            
            modelBuilder.Entity<UserRole>().HasData(new List<UserRole>
            {
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = users["Admin"].Id,
                    RoleId = roles["Admin"].Id
                },
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = users["Guest"].Id,
                    RoleId = roles["Guest"].Id
                },
            });
        }

    }
}
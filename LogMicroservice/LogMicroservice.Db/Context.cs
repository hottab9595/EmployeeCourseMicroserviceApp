using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmployeeMicroservice.Db.Models;
using LogMicroservice.Db.Interfaces;

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

        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder
                .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Log>()
                .Property(u => u.Message)
                .HasComputedColumnSql("CAST([CurrentDateTime] AS nvarchar(40)) + '_' + [IpAddress] + '_' + CAST([UserId] AS nvarchar(50)) + '_' + [Operation]");

            modelBuilder.Entity<Log>()
                .Property(u => u.CurrentServerDateTime)
                .HasDefaultValueSql("getdate()");

        }
    }
}
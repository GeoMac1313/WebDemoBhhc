using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArchitecture.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //private readonly IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Reason> Reasons { get; set; }  //Create the Reasons context

        //Define the schema
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Reasons
            builder.Entity<Reason>().Property(r => r.Description).HasMaxLength(500);
            builder.Entity<Reason>().Property(r => r.LastChangedBy).HasMaxLength(100);
        }
    }

    // required when local database deleted
    public class ReasonContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=localhost;Database=BhhcDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
                      
            return new AppDbContext(builder.Options);
        }
    }
}

using AshalLms.Core.DomainModels.UsersModels;
using Core.DomaimModels;
using Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Reflection;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ValidationCode> ValidationCodes { get; set; }
        public DbSet<User> Users { get; set; }

    


        public DbSet<NotificationModel> NotificationModels { get; set; }
        public DbSet<Message> Messages { get; set; }
  
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

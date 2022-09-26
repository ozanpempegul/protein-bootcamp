using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace cacheHW.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Person>(builder =>
            {                
                builder.ToTable("person");
            });
        }
    }
}

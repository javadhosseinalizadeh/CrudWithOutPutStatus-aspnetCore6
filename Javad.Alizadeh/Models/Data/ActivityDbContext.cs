using Javad.Alizadeh.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Javad.Alizadeh.Models.Data
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext(DbContextOptions<ActivityDbContext> options) : base(options)
        {

        }
        public ActivityDbContext()
        {

        }
        public DbSet<ActivityType> ActivityTypes { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}

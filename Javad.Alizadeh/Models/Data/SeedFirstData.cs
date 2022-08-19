using Javad.Alizadeh.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Javad.Alizadeh.Models.Data
{
    public static class SeedFirstData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<ActivityType>()
                .HasData(new ActivityType
                {
                    Id = 1,
                    Name = "test",
                    Code = 1234,
                    CreatedTime = DateTime.Now,
                    IsActive = true,
                });
        }
    }
}

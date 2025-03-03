using CropService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CropService.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Crops.Any())
            {
                context.Crops.AddRange(
                    new Crop
                    {
                        Id = Guid.NewGuid(),
                        FarmerId = Guid.NewGuid(),
                        CropType = "Tomato",
                        Quantity = 100,
                        PricePerKg = 1.5m,
                        Location = "Farm A",
                        Status = "Available",
                        CreatedAt = DateTime.UtcNow
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

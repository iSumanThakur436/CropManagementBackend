using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AuthService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Models.Role { Id = Guid.NewGuid(), Name = "Farmer" },
                    new Models.Role { Id = Guid.NewGuid(), Name = "Dealer" },
                    new Models.Role { Id = Guid.NewGuid(), Name = "Admin" }
                );
                context.SaveChanges();
            }
        }
    }
}
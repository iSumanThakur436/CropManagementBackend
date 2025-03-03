using Microsoft.EntityFrameworkCore;
using CropService.Models;

namespace CropService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Crop> Crops { get; set; }
    }
}

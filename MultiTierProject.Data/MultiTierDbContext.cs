using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Models;
using MultiTierProject.Data.Configurations;

namespace MultiTierProject.Data
{
    public class MultiTierDbContext : DbContext
    {
        public MultiTierDbContext(DbContextOptions<MultiTierDbContext> option) : base(option) {}
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
        }
    }
}

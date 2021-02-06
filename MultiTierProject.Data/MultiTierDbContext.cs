using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Models;
using MultiTierProject.Data.Configurations;
using MultiTierProject.Data.Seeds;

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

            modelBuilder.ApplyConfiguration(new CitySeed(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new RegionSeed(new int[] { 1, 2, 3 }));
        }
    }
}

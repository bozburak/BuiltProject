using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Models;
using MultiTierProject.Data.Configurations;
using MultiTierProject.Data.Seeds;

namespace MultiTierProject.Data
{
    public class MultiTierDbContext : DbContext
    {
        public MultiTierDbContext(DbContextOptions<MultiTierDbContext> option) : base(option) {}
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            modelBuilder.ApplyConfiguration(new TaskSeed(new int[] { 1, 2, 3 }));
        }
    }
}

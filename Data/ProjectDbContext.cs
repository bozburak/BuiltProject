using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data.Configurations;
using Data.Seeds;

namespace Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) {}
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ClaimConfiguration());
            modelBuilder.ApplyConfiguration(new UserClaimConfiguration());

            modelBuilder.ApplyConfiguration(new TaskSeed(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2, 3 }));
            modelBuilder.ApplyConfiguration(new ClaimSeed());
        }
    }
}

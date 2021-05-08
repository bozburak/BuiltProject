using Microsoft.EntityFrameworkCore;
using Core.Models;
using Data.Configurations;
using Data.Seeds;

namespace Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> option) : base(option) {}
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            modelBuilder.ApplyConfiguration(new TaskSeed(new string[] { "1", "2", "3" }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new string[] { "1", "2", "3" }));
        }
    }
}

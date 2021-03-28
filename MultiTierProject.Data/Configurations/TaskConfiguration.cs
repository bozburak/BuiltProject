using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Data.Configurations
{
    class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Status).IsRequired();
            builder.ToTable("Task");
        }
    }
}

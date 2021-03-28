using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Data.Seeds
{
    class TaskSeed : IEntityTypeConfiguration<Task>
    {
        private readonly int[] _ids;

        public TaskSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData
            (
                new Task { Id = 1, Name = "First Task", Status = true },
                new Task { Id = 2, Name = "Second Task", Status = true },
                new Task { Id = 3, Name = "Third Task", Status = true }
            );
        }
    }
}

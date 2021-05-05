using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Data.Seeds
{
    public class TaskSeed : IEntityTypeConfiguration<Task>
    {
        private readonly string[] _ids;

        public TaskSeed(string[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData
            (
                new Task { Id = "1", Name = "First Task", Status = true, CategoryId = _ids[0] },
                new Task { Id = "2", Name = "Second Task", Status = true, CategoryId = _ids[1] },
                new Task { Id = "3", Name = "Third Task", Status = true, CategoryId = _ids[2] }
            );
        }
    }
}

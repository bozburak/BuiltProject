using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly string[] _ids;

        public CategorySeed(string[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Task { Id = "1", Name = "First Category", Status = true },
                new Task { Id = "2", Name = "Second Category", Status = true },
                new Task { Id = "3", Name = "Third Category", Status = true }
            );
        }
    }
}

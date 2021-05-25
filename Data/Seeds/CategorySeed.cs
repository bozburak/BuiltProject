using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;

        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category { Id = _ids[0], Name = "First Category", IsDeleted = false },
                new Category { Id = _ids[1], Name = "Second Category", IsDeleted = false },
                new Category { Id = _ids[2], Name = "Third Category", IsDeleted = false }
            );
        }
    }
}

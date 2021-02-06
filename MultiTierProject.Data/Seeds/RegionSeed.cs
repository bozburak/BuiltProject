using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Data.Seeds
{
    class RegionSeed : IEntityTypeConfiguration<Region>
    {
        private readonly int[] _ids;
        public RegionSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasData
            (
                new Region { Id = _ids[0], Name = "Marmara" },
                new Region { Id = _ids[1], Name = "Ege" },
                new Region { Id = _ids[2], Name = "İç Anadolu" }
            );
        }
    }
}

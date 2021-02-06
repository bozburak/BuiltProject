using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Data.Seeds
{
    class CitySeed : IEntityTypeConfiguration<City>
    {
        private readonly int[] _ids;

        public CitySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData
            (
                new City { Id = 1, Name = "İstanbul", RegionId = _ids[0] },
                new City { Id = 2, Name = "İzmir", RegionId = _ids[1] },
                new City { Id = 3, Name = "Ankara", RegionId = _ids[2] }
            );
        }
    }
}

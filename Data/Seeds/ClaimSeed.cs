using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Data.Seeds
{
    public class ClaimSeed : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.HasData
            (
                new Claim { Id = 1, Name = "admin" }
            );
        }
    }
}

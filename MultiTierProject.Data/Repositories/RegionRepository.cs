using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Data.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private MultiTierDbContext _multiTierDbContext { get => _context as MultiTierDbContext; }
        public RegionRepository(MultiTierDbContext dbContext) : base(dbContext) { }
        public async Task<Region> GetWithCitiesByIdAsync(int regionId)
        {
            return await _multiTierDbContext.Regions.Include(x => x.Cities).SingleOrDefaultAsync(x => x.Id == regionId);
        }
    }
}

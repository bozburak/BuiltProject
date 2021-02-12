using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Models;
using System;
using System.Threading.Tasks;

namespace MultiTierProject.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private MultiTierDbContext _multiTierDbContext { get => _context as MultiTierDbContext; }
        public CityRepository(MultiTierDbContext dbContext) : base(dbContext) { }
        public async Task<City> GetWithRegionByIdAsync(int cityId)
        {
            return await _multiTierDbContext.Cities.Include(x => x.Region).SingleOrDefaultAsync(x => x.Id == cityId);
        }
    }
}

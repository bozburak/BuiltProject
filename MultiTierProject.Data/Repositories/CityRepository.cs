using Microsoft.EntityFrameworkCore;
using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Models;
using System;
using System.Threading.Tasks;

namespace MultiTierProject.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private MultiTierDbContext MultiTierDbContext { get => _context as MultiTierDbContext; }
        public CityRepository(DbContext dbContext) : base(dbContext) { }
        public async Task<City> GetWithRegionByIdAsync(int cityId)
        {
            return await MultiTierDbContext.Cities.Include(x => x.Region).SingleOrDefaultAsync(x => x.Id == cityId);
        }
    }
}

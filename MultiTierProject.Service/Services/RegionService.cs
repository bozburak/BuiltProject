using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Service.Services
{
    public class RegionService : Service<Region>, IRegionService
    {
        ////private readonly IRegionRepository _regionRepository;
        //public RegionService(IUnitOfWork unitOfWork, IRepository<Region> repository, IRegionRepository regionRepository) : base(unitOfWork, repository)
        //{
        //    _regionRepository = regionRepository;
        //}
        public RegionService(IUnitOfWork unitOfWork, IRepository<Region> repository) : base(unitOfWork, repository)
        {
        }

        public Task<Region> GetWithCitiesByIdAsync(int regionId)
        {
            throw new System.NotImplementedException();
        }

        //async Task<Region> IRegionService.GetWithCitiesByIdAsync(int regionId)
        //{
        //    return await _regionRepository.GetWithCitiesByIdAsync(regionId);
        //}
    }
}

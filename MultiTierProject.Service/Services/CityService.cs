using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Service.Services
{
    public class CityService : Service<City>, ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(IUnitOfWork unitOfWork, IRepository<City> repository, ICityRepository cityRepository) : base(unitOfWork, repository)
        {
            _cityRepository = cityRepository;
        }
        async Task<City> ICityService.GetWithRegionByIdAsync(int cityId)
        {
            return await _cityRepository.GetWithRegionByIdAsync(cityId);
        }
    }
}

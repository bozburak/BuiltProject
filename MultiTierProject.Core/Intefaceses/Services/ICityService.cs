using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Services
{
    public interface ICityService : IService<City>
    {
        Task<City> GetWithRegionByIdAsync(int cityId);
    }
}

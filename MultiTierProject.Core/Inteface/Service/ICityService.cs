using MultiTierProject.Core.Model;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.Service
{
    public interface ICityService : IService<City>
    {
        Task<Region> GetWithRegionByIdAsync(int cityId);
    }
}

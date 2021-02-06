using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<Region> GetWithRegionByIdAsync(int cityId);
    }
}

using MultiTierProject.Core.Model;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.Repository
{
    interface ICityRepository : IRepository<City>
    {
        Task<Region> GetWithRegionByIdAsync(int cityId);
    }
}

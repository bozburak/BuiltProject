using MultiTierProject.Core.Model;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.Repository
{
    interface IRegionRepository : IRepository<Region>
    {
        Task<Region> GetWithCitiesByIdAsync(int regionId);
    }
}

using MultiTierProject.Core.Model;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.Repository
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<Region> GetWithCitiesByIdAsync(int regionId);
    }
}

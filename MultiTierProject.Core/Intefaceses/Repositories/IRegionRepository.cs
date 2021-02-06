using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<Region> GetWithCitiesByIdAsync(int regionId);
    }
}

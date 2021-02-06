using MultiTierProject.Core.Models;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Services
{
    public interface IRegionService : IService<Region>
    {
        Task<Region> GetWithCitiesByIdAsync(int regionId);
    }
}

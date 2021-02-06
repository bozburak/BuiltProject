using MultiTierProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Inteface.Service
{
    public interface IRegionService : IService<Region>
    {
        Task<Region> GetWithCitiesByIdAsync(int regionId);
    }
}

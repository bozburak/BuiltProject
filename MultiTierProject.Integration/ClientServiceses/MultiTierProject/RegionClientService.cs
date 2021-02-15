using System.Net.Http;

namespace MultiTierProject.Integration.ClientServiceses.MultiTierProject
{
    public class RegionClientService<TEntity> : GenericClientService<TEntity> where TEntity : class
    {
        public RegionClientService(HttpClient httpClient) : base(httpClient, "regions")
        {
        }
    }
}

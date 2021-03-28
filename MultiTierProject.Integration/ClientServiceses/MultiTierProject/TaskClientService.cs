using System.Net.Http;

namespace MultiTierProject.Integration.ClientServiceses.MultiTierProject
{
    public class TaskClientService<TEntity> : GenericClientService<TEntity> where TEntity : class
    {
        public TaskClientService(HttpClient httpClient) : base(httpClient, "tasks")
        {
        }
    }
}

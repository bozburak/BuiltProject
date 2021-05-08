using System.Net.Http;

namespace Integration.ClientServiceses.ExampleProject
{
    public class TaskClientService<TEntity> : GenericClientService<TEntity> where TEntity : class
    {
        public TaskClientService(HttpClient httpClient) : base(httpClient, "tasks")
        {
        }
    }
}

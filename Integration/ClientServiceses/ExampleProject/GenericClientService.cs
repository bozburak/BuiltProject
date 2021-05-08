using Core.Intefaceses.Integration;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Integration.ClientServiceses.ExampleProject
{
    public abstract class GenericClientService<TEntity> : IIntegrationProjectClient<TEntity> where TEntity : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endPoint;
        public GenericClientService(HttpClient httpClient, string endPoint)
        {
            _httpClient = httpClient;
            _endPoint = endPoint;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> regionDtos;

            var response = await _httpClient.GetAsync(_endPoint);

            if (response.IsSuccessStatusCode)
            {
                regionDtos = JsonSerializer.Deserialize<IEnumerable<TEntity>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                regionDtos = null;
            }
            return regionDtos;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity regionDto;

            var response = await _httpClient.GetAsync($"{_endPoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                regionDto = JsonSerializer.Deserialize<TEntity>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                regionDto = null;
            }
            return regionDto;
        }

        public async Task<TEntity> AddAsync(TEntity regionDto)
        {
            var request = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json"); 
            var response = await _httpClient.PostAsync(_endPoint, request);

            if (response.IsSuccessStatusCode)
            {
                regionDto = JsonSerializer.Deserialize<TEntity>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                regionDto = null;
            }
            return regionDto;
        }

        public TEntity Update(TEntity regionDto)
        {
            var request = new StringContent(JsonSerializer.Serialize(regionDto), Encoding.UTF8, "application/json");
            var response =  _httpClient.PutAsync(_endPoint, request).Result;

            if (response.IsSuccessStatusCode)
            {
                regionDto = JsonSerializer.Deserialize<TEntity>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                regionDto = null;
            }
            return regionDto;
        }

        public bool Remove(int id)
        {
            var response = _httpClient.DeleteAsync($"{_endPoint}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

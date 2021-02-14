using MultiTierProject.Web.AutoMapper.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MultiTierProject.Web.ClientServiceses
{
    public class RegionClientService
    {
        private readonly HttpClient _httpClient;
        public RegionClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RegionDto>> GetAllAsync()
        {
            IEnumerable<RegionDto> regionDtos;

            var response = await _httpClient.GetAsync("regions");

            if (response.IsSuccessStatusCode)
            {
                regionDtos = JsonConvert.DeserializeObject<IEnumerable<RegionDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                regionDtos = null;
            }
            return regionDtos;
        }

        public async Task<RegionDto> AddAsync(RegionDto regionDto)
        {
            var request = new StringContent(JsonConvert.SerializeObject(regionDto), Encoding.UTF8, "application/json"); 
            var response = await _httpClient.PostAsync("regions", request);

            if (response.IsSuccessStatusCode)
            {
                regionDto = JsonConvert.DeserializeObject<RegionDto>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                regionDto = null;
            }
            return regionDto;
        }

        public RegionDto Update(RegionDto regionDto)
        {
            var request = new StringContent(JsonConvert.SerializeObject(regionDto), Encoding.UTF8, "application/json");
            var response =  _httpClient.PutAsync("regions", request).Result;

            if (response.IsSuccessStatusCode)
            {
                regionDto = JsonConvert.DeserializeObject<RegionDto>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                regionDto = null;
            }
            return regionDto;
        }

        public bool Remove(int id)
        {
            var response = _httpClient.DeleteAsync("regions/" + id).Result;

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

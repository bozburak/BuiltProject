using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiTierProject.Core.AutoMapper.DTOs;
using MultiTierProject.Integration.ClientServiceses.MultiTierProject;
using MultiTierProject.Web.Filters;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MultiTierProject.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly ILogger<RegionsController> _logger;
        private readonly RegionClientService<RegionDto> _apiClient;

        public RegionsController(RegionClientService<RegionDto> apiClient, ILogger<RegionsController> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var regions = await _regionService.GetAllAsync();
            var result = await _apiClient.GetAllAsync();
            _logger.LogInformation("GetAll");
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> Create(RegionDto regionDto)
        {
            //var newRegion = await _regionService.AddAsync(_mapper.Map<Region>(regionDto));
            var result = await _apiClient.AddAsync(regionDto);
            var resultJson = JsonConvert.SerializeObject(result);
            _logger.LogInformation($"Added Region: {resultJson}" );
            return Json(resultJson);
        }

        [HttpPut]
        public JsonResult Update(RegionDto regionDto)
        {
            //var updateRegion = _regionService.Update(_mapper.Map<Region>(regionDto));
            var result = _apiClient.Update(regionDto);
            _logger.LogInformation($"Updated Region Name: {result?.Name}");
            return Json(result);
        }
        
        [ServiceFilter(typeof(NotFoundFilterForRegion))]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //var region = _regionService.GetByIdAsync(id).Result;
            //_regionService.Remove(region);
            var result = _apiClient.Remove(id);
            _logger.LogInformation($"is it removed region?: {result}");
            return Json(result);
        }
    }
}

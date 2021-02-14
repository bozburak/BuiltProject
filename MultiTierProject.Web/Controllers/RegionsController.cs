using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Models;
using MultiTierProject.Web.AutoMapper.DTOs;
using MultiTierProject.Web.ClientServiceses;
using MultiTierProject.Web.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTierProject.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;
        private readonly RegionClientService _apiClient;

        public RegionsController(IRegionService regionService, IMapper mapper, RegionClientService apiClient)
        {
            _regionService = regionService;
            _mapper = mapper;
            _apiClient = apiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var regions = await _regionService.GetAllAsync();
            var result = await _apiClient.GetAllAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> Create(RegionDto regionDto)
        {
            //var newRegion = await _regionService.AddAsync(_mapper.Map<Region>(regionDto));
            var result = await _apiClient.AddAsync(regionDto);
            return Json(JsonConvert.SerializeObject(result));
        }

        [HttpPut]
        public JsonResult Update(RegionDto regionDto)
        {
            //var updateRegion = _regionService.Update(_mapper.Map<Region>(regionDto));
            var result = _apiClient.Update(regionDto);
            return Json(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Region>))]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //var region = _regionService.GetByIdAsync(id).Result;
            //_regionService.Remove(region);
            var result = _apiClient.Remove(id);
            return Json(result);
        }
    }
}

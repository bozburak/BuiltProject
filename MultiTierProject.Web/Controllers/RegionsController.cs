using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Models;
using MultiTierProject.Web.AutoMapper.DTOs;
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

        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var regions = await _regionService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<RegionDto>>(regions));
        }

        [HttpPost]
        public async Task<JsonResult> Create(RegionDto regionDto)
        {
            var newRegion = await _regionService.AddAsync(_mapper.Map<Region>(regionDto));
            return Json(JsonConvert.SerializeObject(newRegion));
        }

        [HttpPut]
        public JsonResult Update(RegionDto regionDto)
        {
            var updateRegion = _regionService.Update(_mapper.Map<Region>(regionDto));
            return Json(JsonConvert.SerializeObject(updateRegion));
        }

        [ServiceFilter(typeof(NotFoundFilter<Region>))]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var region = _regionService.GetByIdAsync(id).Result;
            _regionService.Remove(region);
            return Json(_mapper.Map<RegionDto>(region));
        }
    }
}

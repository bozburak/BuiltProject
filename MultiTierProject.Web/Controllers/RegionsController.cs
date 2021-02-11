using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Models;
using MultiTierProject.Web.AutoMapper.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTierProject.Web.Controllers
{
    public class RegionsController : Controller
    {
        private readonly Region _region;
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionsController(IRegionService regionService, IMapper mapper, Region region)
        {
            _regionService = regionService;
            _mapper = mapper;
            _region = region;
        }
        public async Task<IActionResult> Index()
        {
            var regions = await _regionService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<RegionDto>>(regions));
        }

        [HttpPost]
        public async Task<JsonResult> Created(string name)
        {
            _region.Name = name;
            var newRegion = await _regionService.AddAsync(_region);
            return Json(JsonConvert.SerializeObject(_mapper.Map<RegionDto>(newRegion)));
        }
    }
}

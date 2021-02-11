using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTierProject.API.AutoMapper.DTOs;
using MultiTierProject.API.Filters;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTierProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;
        public RegionsController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _regionService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));
        }

        [ServiceFilter(typeof(NotFoundFilter<Region>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var region = await _regionService.GetByIdAsync(id);
            return Ok(_mapper.Map<RegionDto>(region));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(RegionDto region)
        {
            var newRegion = await _regionService.AddAsync(_mapper.Map<Region>(region));
            return Created(string.Empty, _mapper.Map<RegionDto>(newRegion));
        }

        [HttpPut]
        public IActionResult Update(RegionDto region)
        {
            var updateRegion = _regionService.Update(_mapper.Map<Region>(region));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Region>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var region = _regionService.GetByIdAsync(id).Result;
            _regionService.Remove(region);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Region>))]
        [HttpGet("{id}/cities")]
        public async Task<IActionResult> GetWithCitiesByIdAsync(int id)
        {
            var region = await _regionService.GetWithCitiesByIdAsync(id);
            return Ok(_mapper.Map<RegionWithCityDto>(region));
        }
    }
}

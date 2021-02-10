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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CityDto>>(cities));
        }

        [ServiceFilter(typeof(NotFoundFilter<City>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
            return Ok(_mapper.Map<CityDto>(city));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(CityDto city)
        {
            var newcity = await _cityService.AddAsync(_mapper.Map<City>(city));
            return Created(string.Empty, _mapper.Map<CityDto>(newcity));
        }

        [HttpPut]
        public IActionResult Update(CityDto city)
        {
            var updatecity = _cityService.Update(_mapper.Map<City>(city));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<City>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var city = _cityService.GetByIdAsync(id).Result;
            _cityService.Remove(city);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<City>))]
        [HttpGet("{id}/region")]
        public async Task<IActionResult> GetWithCitiesByIdAsync(int id)
        {
            var city = await _cityService.GetWithRegionByIdAsync(id);
            return Ok(_mapper.Map<CityWithRegionDto>(city));
        }
    }
}

using AutoMapper;
using MannuBusinessWebApi.Controllers.Resources;
using MannuBusinessWebApi.Models;
using MannuBusinessWebApi.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MannuBusinessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly MannuDbContext _context;
        private readonly IMapper _mapper;

        public AddressController(
            IMapper mapper,
            MannuDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.Include(c => c.Provinces).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries));
        }

        [HttpGet("provinces/{countryId}")]
        public async Task<IActionResult> GetProvinces([FromRoute] int countryId)
        {
            var provinces = await _context.Provinces.Where(p => p.CountryId == countryId).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceResource>>(provinces));
        }

        [HttpGet("cities/{provinceId}")]
        public async Task<IActionResult> GetCities([FromRoute] int provinceId)
        {
            var cities = await _context.Cities.Where(c => c.ProvinceId == provinceId).ToListAsync();

            return Ok(_mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities));
        }
    }
}

using AutoMapper;
using MannuBusinessWebApi.Controllers.Resources;
using MannuBusinessWebApi.Models;
using MannuBusinessWebApi.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MannuBusinessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MannuDbContext _context;

        public BusinessesController(
            IMapper mapper,
            MannuDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinesses()
        {
            var business = await _context.Businesses
                .Include(b => b.BusinessType)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<Business>, IEnumerable<BusinessResource>>(business));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusiness([FromRoute] int id)
        {
            var business = await _context.Businesses
                .Include(b => b.BusinessType)
                .Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (business == null)
                return NotFound();

            business.Address.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == business.Address.CountryId);
            business.Address.Province = await _context.Provinces.FirstOrDefaultAsync(c => c.Id == business.Address.ProvinceId);
            business.Address.City = await _context.Cities.FirstOrDefaultAsync(c => c.Id == business.Address.CityId);

            return Ok(_mapper.Map<Business, GetBusinessResource>(business));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusiness([FromBody] CreateBusinessResource businessResource)
        {
            var business = _mapper.Map<CreateBusinessResource, Business>(businessResource);

            await _context.Businesses.AddAsync(business);
            await _context.SaveChangesAsync();

            business.Address.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == business.Address.CountryId);
            business.Address.Province = await _context.Provinces.FirstOrDefaultAsync(c => c.Id == business.Address.ProvinceId);
            business.Address.City = await _context.Cities.FirstOrDefaultAsync(c => c.Id == business.Address.CityId);

            var result = _mapper.Map<Business, GetBusinessResource>(business);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusiness(int id, CreateBusinessResource businessResource)
        {
            var business = await _context.Businesses
                .Include(b => b.Address)
                .Include(b => b.BusinessType)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (business == null)
                return NotFound();

            _mapper.Map(businessResource, business);

            await _context.SaveChangesAsync();

            business.Address.Country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == business.Address.CountryId);
            business.Address.Province = await _context.Provinces.FirstOrDefaultAsync(c => c.Id == business.Address.ProvinceId);
            business.Address.City = await _context.Cities.FirstOrDefaultAsync(c => c.Id == business.Address.CityId);

            return Ok(_mapper.Map<Business, GetBusinessResource>(business));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id, [FromBody] DeleteBusinessResource resource)
        {
            var business = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

            if (business == null)
                return NotFound();

            business.BusinessClosingMessage = resource.BusinessClosingMessage;
            business.IsBusinessClose = true;

            await _context.SaveChangesAsync();

            return Ok(id);
        }
    }
}

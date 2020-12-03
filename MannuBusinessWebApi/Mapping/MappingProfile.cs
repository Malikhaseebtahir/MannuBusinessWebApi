using AutoMapper;
using MannuBusinessWebApi.Controllers.Resources;
using MannuBusinessWebApi.Models;

namespace MannuBusinessWebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model to ApiResource
            CreateMap<City, CityResource>();
            CreateMap<Province, ProvinceResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Business, GetBusinessResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<Business, BusinessResource>();
            CreateMap<BusinessTypes, BusinessTypesResource>();

            // Resource to Model
            CreateMap<CityResource, City>();
            CreateMap<ProvinceResource, Province>();
            CreateMap<CountryResource, Country>();
            CreateMap<CreateBusinessResource, Business>();
            CreateMap<CreateAddressResource, Address>();
        }
    }
}
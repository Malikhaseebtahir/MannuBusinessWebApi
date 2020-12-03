namespace MannuBusinessWebApi.Controllers.Resources
{
    public class AddressResource
    {
        public CountryResource Country { get; set; }
        public ProvinceResource Province { get; set; }
        public CityResource City { get; set; }

        public string ShopLocation { get; set; }
    }
}
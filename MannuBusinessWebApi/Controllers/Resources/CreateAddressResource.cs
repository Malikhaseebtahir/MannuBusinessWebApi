namespace MannuBusinessWebApi.Controllers.Resources
{
    public class CreateAddressResource
    {
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string ShopLocation { get; set; }
    }
}
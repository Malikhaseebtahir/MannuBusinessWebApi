namespace MannuBusinessWebApi.Models
{
    public class Address
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public string ShopLocation { get; set; }
    }
}
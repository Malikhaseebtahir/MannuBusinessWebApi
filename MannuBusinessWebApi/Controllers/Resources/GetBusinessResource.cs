namespace MannuBusinessWebApi.Controllers.Resources
{
    public class GetBusinessResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public BusinessTypesResource BusinessType { get; set; }
        public AddressResource Address { get; set; }
        public bool FamilyBusiness { get; set; }
        public bool BusinessOtherThanFamilyPerson { get; set; }
        public string BusinessPartnerName { get; set; }
        public int MonthlyProfit { get; set; }
        public int AnnualProfit { get; set; }
        public bool Investor { get; set; }
        public int TotalLoss { get; set; }
        public int TotalProfit { get; set; }
    }
}
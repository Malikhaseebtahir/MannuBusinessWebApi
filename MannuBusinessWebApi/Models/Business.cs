namespace MannuBusinessWebApi.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public int BusinessTypeId { get; set; }
        public BusinessTypes BusinessType { get; set; }
        public Address Address { get; set; }
        public bool FamilyBusiness { get; set; }
        public bool BusinessOtherThanFamilyPerson { get; set; }
        public string BusinessPartnerName { get; set; }
        public int MonthlyProfit { get; set; }
        public int AnnualProfit { get; set; }
        public bool Investor { get; set; }
        public int TotalLoss { get; set; }
        public int TotalProfit { get; set; }
        public string BusinessClosingMessage { get; set; }
        public bool IsBusinessClose { get; set; }
    }
}
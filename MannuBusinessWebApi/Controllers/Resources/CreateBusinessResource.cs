namespace MannuBusinessWebApi.Controllers.Resources
{
    public class CreateBusinessResource
    {
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public int BusinessTypeId { get; set; }
        public CreateAddressResource Address { get; set; }
        public bool FamilyBusiness { get; set; }
        public bool BusinessOtherThanFamilyPerson { get; set; }
        public string BusinessPartnerName { get; set; }
        public bool Investor { get; set; }
    }
}
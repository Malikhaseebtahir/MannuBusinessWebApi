namespace MannuBusinessWebApi.Controllers.Resources
{
    public class BusinessResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public BusinessTypesResource BusinessType { get; set; }
    }
}
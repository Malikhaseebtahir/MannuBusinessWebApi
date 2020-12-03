using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MannuBusinessWebApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Province> Provinces { get; set; } = new Collection<Province>();
    }
}
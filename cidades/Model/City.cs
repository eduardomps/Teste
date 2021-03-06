using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace cidades.Model
{
    public class City
    {
        public int? Id {get;set;}
        public string Name {get;set;}
        public int Population {get;set;}
        public string CountryState {get;set;} 
        [JsonIgnore]
        public List<CityToCity> CityRoutes {get;set;} = new List<CityToCity>();
        [JsonIgnore]
        public List<CityToCity> CityRoutesFrom {get;set;} = new List<CityToCity>();
        
        public List<City> Neighbors
        {
            get
            {
                var listTo = CityRoutes.Select(r => r.CityTo).ToList();
                var listFrom = CityRoutesFrom.Select(r => r.City)
                    .Where(c => !listTo.Contains(c))
                    .ToList();
                listTo.AddRange(listFrom);
                return listTo;
            }
        }

        
    }
}
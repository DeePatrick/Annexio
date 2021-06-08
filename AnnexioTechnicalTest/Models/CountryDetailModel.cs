using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Models
{
    public class CountryDetailModel
    {
        public string Name { get; set; }
        public string CapitalCity { get; set; }
        public string TotalPopulation { get; set; }

        public List<Currency> Currencies { get; set; }
        public List<Language> Langauages{ get; set; }

        public List<Country> NeighborCountries { get; set; }
    }
}



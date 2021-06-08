using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Models
{
    public class Region
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Population { get; set; }
        public List<Country> Countries { get; set; }

        public List<SubRegion> SubRegions { get; set; }

    }
}

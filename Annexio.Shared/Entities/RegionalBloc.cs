using System.Collections.Generic;

namespace Annexio.Library.Entities
{
    public class RegionalBloc
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public List<string> OtherAcronym { get; set; } = new();

        public List<string> OtherNames { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Annexio.Library.Entities
{
    public class Country
    {
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<string> TopLevelDomain { get; set; } = new();
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public List<string> CallingCodes { get; set; } = new();
        public string Capital { get; set; }
        public List<string> AltSpelling { get; set; } = new();

        public string SubRegion { get; set; }

        public int Population { get; set; }

        public List<double> LatLag { get; set; } = new();

        public string Demonym { get; set; }

        public object Area { get; set; }
        public object Gini { get; set; }

        public List<string> TimeZones { get; set; } = new();

        public List<string> Borders { get; set; } = new();

        public string NativeName { get; set; }

        public string NumericCode { get; set; }

        public List<Currency> Currencies { get; set; } = new();

        public List<Language> Languages { get; set; } = new();

        public List<Translation> Transaltions { get; set; } = new();

        public List<RegionalBloc> RegionalBlocs { get; set; } = new();

        public string Flag { get; set; } //Image

        public string Cioc { get; set; }


        public string NameBrief
        {
            get
            {
                if (String.IsNullOrEmpty(Name))
                {
                    return null;
                }
                if (Name.Length > 60)

                {
                    return Name.Substring(0, 60) + "...";
                }
                else
                {
                    return Name;
                }
            }
        }

    }
}



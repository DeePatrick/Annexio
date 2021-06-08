﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Models
{
    public class CountryDetailModel
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }

       public List<Currency> Currencies { get; set; }
        public List<Language> Languages{ get; set; }

        public List<string> Borders { get; set; }
    }
}




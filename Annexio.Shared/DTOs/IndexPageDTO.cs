using Annexio.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Annexio.Library.DTOs
{
    public class IndexPageDTO
    {
        public List<Country> InTheatres { get; set; }
        public List<Country> UpcomingReleases { get; set; }
    }
}


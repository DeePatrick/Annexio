using System;
using System.Collections.Generic;
using System.Text;

namespace Annexio.Library.DTOs
{
    public class FilteredCountriesDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerpage { get; set; } = 10;

        public PaginationDTO Pagination
        {
            get
            {
                return new PaginationDTO()
                {
                    Page = Page,
                    RecordsPerPage = RecordsPerpage
                };
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Helpers
{
    public class FilterCountries
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;

        public string SearchString { get; set; }

        public string CurrentFilter { get; set; }

        public string SortOrder { get; set; }

        //public PaginationDTO Pagination
        //{
            //get { return new PaginationDTO() { Page = Page, RecordsPerPage = RecordsPerPage }; }
        //}
    }
}




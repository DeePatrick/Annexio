using System;
using System.Collections.Generic;
using System.Text;

namespace Annexio.Library.DTOs
{
    public class PaginatedResponse<T>
    {
        public T Response { get; set; }
        public int TotalAmountPages { get; set; }

    }
}



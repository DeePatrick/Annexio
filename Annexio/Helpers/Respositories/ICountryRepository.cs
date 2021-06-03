using Annexio.Library.DTOs;
using Annexio.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Annexio.Helpers.Respositories
{
    public interface ICountryRepository
    {
        //Task<DetailsCountryDTO> GetDetailsCountryDTO(int id);
        //Task<IndexPageDTO> GetIndexPageDTO();

        Task<List<Country>> GetCountries();

        Task<PaginatedResponse<List<Country>>> GetCountriesFiltered(FilteredCountriesDTO filteredCountriesDTO);
    }
}

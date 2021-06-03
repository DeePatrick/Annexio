using Annexio.Library.DTOs;
using Annexio.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Annexio.Helpers.Respositories
{
    public class CountryRepository: ICountryRepository
    {
        private readonly IHttpService _httpService;
        private string url = "https://restcountries.eu/rest/v2";

        public CountryRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        //public async Task<IndexPageDTO> GetIndexPageDTO()
        //{
        //    return await _httpService.GetHelper<IndexPageDTO>(url);
        //}

        //public async Task<DetailsCountryDTO> GetDetailsCountryDTO(int id)
        //{
        //    return await _httpService.GetHelper<DetailsCountryDTO>($"{url}/{id}");
        //}



        public async Task<List<Country>> GetCountries()
        {
            return await _httpService.GetHelper<List<Country>>($"{url}/all");

        }

        public async Task<PaginatedResponse<List<Country>>> GetCountriesFiltered(FilteredCountriesDTO filteredCountriesDTO)
        {
            var responseHttp = await _httpService.Post<FilteredCountriesDTO, List<Country>>($"{url}/filter", filteredCountriesDTO);
            var totalAmountPages = int.Parse(responseHttp.HttpResponseMessage.Headers.GetValues("totalAmountPages").FirstOrDefault());
            var paginatedResponse = new PaginatedResponse<List<Country>>()
            {
                Response = responseHttp.Response,
                TotalAmountPages = totalAmountPages
            };

            return paginatedResponse;
        }       

    }
}








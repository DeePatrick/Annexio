using AnnexioTechnicalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Services
{
    public interface ICountryApiService
    {
        Task<List<Country>> GetCountries();
        Task<List<CountryDetailModel>> GetCountryDetail(string countryCode);
        Task<List<Region>> GetRegionDetail(string regioncode);
        Task<List<SubRegion>> GetSubregionDetail(string subregioncode);
    }
}
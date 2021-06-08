using AnnexioTechnicalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Services
{
    public interface ICountryApiService
    {
        Task<List<Country>> GetCountries();
        Task<List<CountryDetailModel>> GetCountryDetail(string countryCode);
        Task<List<RegionModel>> GetRegionDetail(string regioncode);
        Task<List<SubRegionModel>> GetSubregionDetail(string subregioncode);
    }
}
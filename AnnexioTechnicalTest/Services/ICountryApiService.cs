using AnnexioTechnicalTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Services
{
    public interface ICountryApiService
    {
        Task<List<Country>> GetCountries();
    }
}
using AnnexioTechnicalTest.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AnnexioTechnicalTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnnexioTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryApiService _countryApiService;

        public HomeController(ICountryApiService countryApiService)
        {
            _countryApiService = countryApiService;
        }

        public async Task<IActionResult> Index()
        {
            List<Country> countries = new List<Country>();
            countries = await _countryApiService.GetCountries();
            return View(countries);
        }

        public async Task<IActionResult> CountryDetail (string Name)
        {
            List<CountryDetailModel> countryDetails = new List<CountryDetailModel>();

            if (!string.IsNullOrEmpty(Name))
            {
                try
                {
                    countryDetails = await _countryApiService.GetCountryDetail(Name);
                }
                catch (Exception)
                {              
                    throw;
                }
            }

            return View(countryDetails);
        }

        public async Task<IActionResult> RegionDetail(string Name)
        {
            List<Region> regionDetails = new List<Region>();

            if (!string.IsNullOrEmpty(Name))
            {
                regionDetails = await _countryApiService.GetRegionDetail(Name);
            }

            return View(regionDetails);
        }

        public async Task<IActionResult> SubRegionDetail(string Name)
        {
            List<SubRegion> subregionDetails = new List<SubRegion>();

            if (!string.IsNullOrEmpty(Name))
            {
                subregionDetails = await _countryApiService.GetSubregionDetail(Name);
            }

            return View(subregionDetails);
        }
    }
}






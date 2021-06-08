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
using AnnexioTechnicalTest.Helpers;

namespace AnnexioTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryApiService _countryApiService;

        public HomeController(ICountryApiService countryApiService)
        {
            _countryApiService = countryApiService;
        }


       
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["RegionSortParm"] = sortOrder == "Region" ? "region_desc" : "Region";
           

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            List<Country> countries = new List<Country>();
            countries = await _countryApiService.GetCountries();
            var countriesQueryable = countries.AsQueryable();

            var sortedItem = from s in countriesQueryable
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sortedItem = sortedItem.Where(s => s.Name.Contains(searchString)
                                       || s.Region.Contains(searchString)
                                       || s.Subregion.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    sortedItem = sortedItem.OrderByDescending(s => s.Name).AsQueryable();
                    break;
                case "Region":
                    sortedItem = sortedItem.OrderBy(s => s.Region).AsQueryable();
                    break;
                case "region_desc":
                    sortedItem = sortedItem.OrderByDescending(s => s.Region).AsQueryable();
                    break;
                default:
                    sortedItem = sortedItem.OrderBy(s => s.Name).AsQueryable();
                    break;
            }


            int pageSize = 5;
            return View(await PaginatedList<Country>.CreateAsync(sortedItem, pageNumber ?? 1, pageSize));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> CountryDetail(string Name)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> RegionDetail(string Name)
        {
            List<RegionModel> regionDetails = new List<RegionModel>();

            if (!string.IsNullOrEmpty(Name))
            {
                regionDetails = await _countryApiService.GetRegionDetail(Name);
            }

            return View(regionDetails);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> SubRegionDetail(string Name)
        {
            List<SubRegionModel> subregionDetails = new List<SubRegionModel>();

            if (!string.IsNullOrEmpty(Name))
            {
                subregionDetails = await _countryApiService.GetSubregionDetail(Name);
            }

            return View(subregionDetails);
        }
    }
}






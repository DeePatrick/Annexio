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
    }
}


using AnnexioTechnicalTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace AnnexioTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpService _httpService;
        private string url = "https://restcountries.eu/rest/v2";

        public CountryRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
 


        [AllowAnonymous]
        [Route("API/GetCountries")]
        public async Task<IActionResult> GetCountries(string user, string pasword)
        {
            string atsakas = "";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://feed-api.gumtree.com/api/users/login");
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    atsakas = responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            return Json(atsakas);
        }

        public class Client
        {
            private Uri baseAddress;

            public Client(Uri baseAddress)
            {
                this.baseAddress = baseAddress;
            }

            public IEnumerable<Products> GetProductsFromCategory(int categoryId)
            {
                return Get<IEnumerable<Product>>($"api/categories/{categoryId}/products");
            }

            public IEnumerable<Products> GetAllProducts()
            {
                return Get<IEnumerable<Product>>($"api/products");
            }

            private T Get<T>(string query)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = baseAddress;

                    var response = httpClient.Get(query).Result;
                    return response.Content.ReadAsAsync<T>().Result;
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

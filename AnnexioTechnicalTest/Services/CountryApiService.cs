using AnnexioTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnnexioTechnicalTest.Services
{
    public class CountryApiService : ICountryApiService
    {
        private readonly HttpClient client;

        public CountryApiService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("CountryInfoApi");
        }

        public async Task<List<Country>> GetCountries()
        {
            var url = string.Format("/rest/v2/all");
            var result = new List<Country>();

            var response = await client.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<Country>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }


        public async Task<List<CountryDetailModel>> GetCountryDetail(string countryCode)
        {
            var url = string.Format("/rest/v2/name/{0}", countryCode);
            var result = new List<CountryDetailModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<CountryDetailModel>>(stringResponse,
                 new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<List<RegionModel>> GetRegionDetail(string regioncode)
        {
            var url = string.Format("/rest/v2/region/{0}", regioncode);
            var result = new List<RegionModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<RegionModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<List<SubRegionModel>> GetSubregionDetail(string subregioncode)
        {
            var url = string.Format("/rest/v2/regionalbloc/{0}", subregioncode);
            var result = new List<SubRegionModel>();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<SubRegionModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}








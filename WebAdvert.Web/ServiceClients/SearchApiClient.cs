using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AdvertApi.ServiceClients;
using Microsoft.Extensions.Configuration;
using WebAdvert.Web.Models;

namespace WebAdvert.Web.ServiceClients
{
    public class SearchApiClient : ISearchApiClient
    {
        private readonly string _baseAddress = string.Empty;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;


        public SearchApiClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            _baseAddress = configuration.GetSection("SearchApi").GetValue<string>("BaseUrl");
        }

        public async Task<List<AdvertType>> Search(string keyword)
        {
            var result = new List<AdvertType>();
            var callUrl = $"{_baseAddress}/search/v1/{keyword}";
            var httpResponse = await _client.GetAsync(new Uri(callUrl)).ConfigureAwait(false);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var allAdverts = await httpResponse.Content.ReadAsAsync<List<AdvertType>>().ConfigureAwait(false);
                result.AddRange(allAdverts);
            }

            return result;
        }
    }
}
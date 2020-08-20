using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.ServiceClients;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAdvert.Web.Models;
using WebAdvert.Web.Models.Home;
using WebAdvert.Web.ServiceClients;

namespace WebAdvert.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchApiClient _searchApiClient;
        private readonly IMapper _mapper;
        private readonly IAdvertApiClient _apiClient;

        public HomeController(ILogger<HomeController> logger, ISearchApiClient searchApiClient, IMapper mapper, IAdvertApiClient apiClient)
        {
            _logger = logger;
            _searchApiClient = searchApiClient;
            _mapper = mapper;
            _apiClient = apiClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var allAds = await _apiClient.GetAllAsync().ConfigureAwait(false);
            var allViewModels = allAds.Select(x => _mapper.Map<IndexViewModel>(x));
            return View(allViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string keyword)
        {
            var viewModel = new List<SearchViewModel>();

            var searchResult = await _searchApiClient.Search(keyword).ConfigureAwait(false);
            searchResult.ForEach(advertDoc =>
            {
                var viewModelItem = _mapper.Map<SearchViewModel>(advertDoc);
                viewModel.Add(viewModelItem);
            });

            return View("Search", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

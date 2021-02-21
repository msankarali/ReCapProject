using Autofac.Features.AttributeFilters;
using Core.Utilities.RestSharp;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpRequestHelper _httpRequestHelper;
        private readonly IApiService _apiService;
        private readonly IApiService _genelParaWebService;

        public HomeController(
            ILogger<HomeController> logger,
            IHttpRequestHelper httpRequestHelper,
            [KeyFilter("WebApi")] IApiService apiService,
            [KeyFilter("GenelParaWebApi")] IApiService genelParaWebService)
        {
            _logger = logger;
            _httpRequestHelper = httpRequestHelper;
            _apiService = apiService;
            _genelParaWebService = genelParaWebService;
        }


        public async Task<IActionResult> Index()
        {
            var rslt = _genelParaWebService.Get<DovizKuru.Rootobject>("doviz.json");

            var asd = _httpRequestHelper.Send<Car>("cars/add", new Car
            {
                BrandId = 1,
                CarId = 2,
                CarName = "BMW",
                ColorId = 1,
                DailyPrice = 100,
                Description = "BMW",
                ModelYear = 2010
            });

            var result = _apiService.Post<ViewDataResult<Car>>("cars/add", new Car
            {
                BrandId = 1,
                CarId = 2,
                CarName = "BMW",
                ColorId = 1,
                DailyPrice = 100,
                Description = "BMW",
                ModelYear = 2010
            });

            return View(await _httpRequestHelper.Get<List<Brand>>("brands/getbrands"));
        }
    }
}
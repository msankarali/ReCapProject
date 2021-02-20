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
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpRequestHelper _httpRequestHelper;

        public HomeController(ILogger<HomeController> logger, IHttpRequestHelper httpRequestHelper)
        {
            _logger = logger;
            _httpRequestHelper = httpRequestHelper;
        }

        public async Task<IActionResult> Index() =>
            View(await _httpRequestHelper.SendRequest<List<Brand>>("brands/getbrands"));
    }
}
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebEnterprise.BackendApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;

namespace WebEnterprise.Admin.Controllers
{
    public class SetTimeController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ISetTimeSystemApiClient _setTimeSystemApiClient;

        public SetTimeController(ISetTimeSystemApiClient setTimeSystemApiClient,

            IConfiguration configuration)
        {
            _configuration = configuration;
            _setTimeSystemApiClient = setTimeSystemApiClient;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SetTimeSystemCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _setTimeSystemApiClient.CreateTime(request);
            if (result)
            {
                TempData["result"] = "Create SetTime success";
                return RedirectToAction("Index", "SetTime");
            }

            ModelState.AddModelError("", "Create SetTime unsuccess");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _setTimeSystemApiClient.GetById(id);
            var editVm = new SetTimeSystemUpdateRequest()
            {
                Id = document.ID,
                StartDay = document.StartDay,
                EndDay = document.EndDay,
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] SetTimeSystemUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _setTimeSystemApiClient.UpdateTime(request);
            if (result)
            {
                TempData["result"] = "Update document succsess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Fail update document");
            return View(request);
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new SetTimeSystemPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _setTimeSystemApiClient.GetAll(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
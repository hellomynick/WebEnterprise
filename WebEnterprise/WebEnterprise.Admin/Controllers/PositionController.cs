using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.ViewModels.Catalog.Positions;

namespace WebEnterprise.Admin.Controllers
{
    public class PositionController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IPositionApiClient _positionApiClient;

        public PositionController(IUserApiClient userApiClient,
            IPositionApiClient positionApiClient,
            IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _positionApiClient = positionApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetPositionsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _positionApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] PositionsCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _positionApiClient.CreatePosition(request);
            if (result)
            {
                TempData["result"] = "Create Document access";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var positions = await _positionApiClient.GetById(id);
            var editVm = new PositionsVm()
            {
                ID = positions.ID,
                Name = positions.Name,
                FacultyID = positions.FacultyID
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] PositionsUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _positionApiClient.UpdatePosition(request);
            if (result)
            {
                TempData["result"] = "Update Position succsess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Fail update position");
            return View(request);
        }
    }
}
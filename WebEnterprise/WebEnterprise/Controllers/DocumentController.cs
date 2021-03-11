using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.Models;
using WebEnterprise.ViewModels.Catalog.Document;

namespace WebEnterprise.Controllers
{
    public class DocumentController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IDocumentApiClient _documentApiClient;

        public DocumentController(IUserApiClient userApiClient,
            IDocumentApiClient documentApiClient,
            IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _documentApiClient = documentApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetDocumentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _documentApiClient.GetByUserID(request);
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
        public async Task<IActionResult> Create([FromForm] DocumentsCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _documentApiClient.CreateDocument(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index", "Document");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new DocumentsDeleteRequest()
            {
                ID = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DocumentsDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _documentApiClient.DeleteDocument(request.ID);
            if (result)
            {
                TempData["result"] = "Delete acccess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cannot delete document");
            return View(request);
        }
    }
}
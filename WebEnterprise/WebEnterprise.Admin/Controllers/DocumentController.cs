using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Aspose.Words;
using System.IO;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.ViewModels.Catalog.Document;
using System.Text;
using Aspose.Words.Saving;
using System.Collections.Generic;

namespace WebEnterprise.Admin.Controllers
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
            var data = await _documentApiClient.GetPagings(request);
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
                TempData["result"] = "Create Document success";
                return RedirectToAction("Index", "Document");
            }

            ModelState.AddModelError("", "Create Document unsuccess");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _documentApiClient.GetById(id);
            var editVm = new DocumentsUpdateRequest()
            {
                Id = document.ID,
                Content = document.Caption,
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] DocumentsUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _documentApiClient.UpdateDocument(request);
            if (result)
            {
                TempData["result"] = "Update document succsess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Fail update document");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> PostDocument(long id)
        {
            var document = await _documentApiClient.GetById(id);
            var editVm = new DocumentsPostRequest()
            {
                ID = document.ID,
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PostDocument([FromForm] DocumentsPostRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _documentApiClient.PostDocument(request);
            if (result)
            {
                TempData["result"] = "Update document succsess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Fail update document");
            return View(request);
        }
    }
}
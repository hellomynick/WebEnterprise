using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.Models;
using WebEnterprise.ViewModels.Catalog.Comment;

namespace WebEnterprise.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IDocumentApiClient _documentApiClient;
        private readonly ICommentApiClient _commentApiClient;

        public CommentController(IUserApiClient userApiClient,
            IDocumentApiClient documentApiClient,
            IConfiguration configuration,
            ICommentApiClient commentApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _documentApiClient = documentApiClient;
            _commentApiClient = commentApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Create(long id, string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetCommentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var document = await _documentApiClient.GetById(id);
            var data = await _commentApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(new CommentViewModel()
            {
                Createcomment = new CommentsCreateRequest()
                {
                    DocumentID = document.ID
                },
                Comments = data
            });
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CommentsCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            var createcomment = await _commentApiClient.CreateComment(request);
            if (createcomment)
            {
                TempData["result"] = "Create Document susscess";
                return RedirectToAction("Create", "Comment");
            }
            return RedirectToAction("Create", "Comment");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new CommentsDeleteRequest()
            {
                ID = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentsDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _commentApiClient.DeleteComment(request.ID);
            if (result)
            {
                TempData["result"] = "Delete acccess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cannot delete document");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _commentApiClient.GetById(id);
            var editVm = new CommentsUpdateRequest()
            {
                ID = document.ID,
                Content = document.Content,
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] CommentsUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _commentApiClient.UpdateComment(request);
            if (result)
            {
                TempData["result"] = "Update document succsess";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Fail update document");
            return View(request);
        }

        public async Task<IActionResult> Comment(long id, string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetCommentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var data = await _commentApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
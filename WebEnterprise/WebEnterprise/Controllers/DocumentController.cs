using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ApiIntegration;
using WebEnterprise.Models;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Catalog.Document;

namespace WebEnterprise.Controllers
{
    public class DocumentController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly IDocumentApiClient _documentApiClient;
        private readonly ICommentApiClient _commentApiClient;

        public DocumentController(IUserApiClient userApiClient,
            IDocumentApiClient documentApiClient,
            IConfiguration configuration, ICommentApiClient commentApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _documentApiClient = documentApiClient;
            _commentApiClient = commentApiClient;
        }

        public async Task<IActionResult> IndexForStudent(string keyword, int pageIndex = 1, int pageSize = 10)
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

        public async Task<IActionResult> IndexForGuest(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetDocumentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _documentApiClient.GetForGuest(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        public async Task<IActionResult> IndexForCoordinator(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetDocumentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _documentApiClient.GetByFaculty(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        public async Task<IActionResult> IndexForManager(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetDocumentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _documentApiClient.GetTotal(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        public async Task<IActionResult> Manager(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetDocumentsPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
            var data = await _documentApiClient.GetForManager(request);
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
                TempData["result"] = "Create Document susscess";
                return RedirectToAction("IndexForStudent", "Document");
            }

            ModelState.AddModelError("", "Create Document Fail");
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
                return RedirectToAction("IndexForCoordinator");
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
                return RedirectToAction("IndexForCoordinator");
            }

            ModelState.AddModelError("", "Fail update document");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Download(long id)
        {
            var document = await _documentApiClient.GetById(id);
            var path = @"C:\Users\DELL\WebEnterprise\WebEnterprise.BackendApi\wwwroot" + document.DocumentPath;
            var filename = document.Caption + ".docx";
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, GetMimeTypes()[ext], Path.GetFileName(filename));
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
        };
        }

        public async Task<FileResult> DownloadZipFile(long id)
        {
            var document = await _documentApiClient.GetById(id);
            var fileName = string.Format("{0}_ImageFiles.zip", DateTime.Today.Date.ToString("dd-MM-yyyy") + "_1");
            var tempOutPutPath = @"C:\Users\DELL\WebEnterprise\WebEnterprise.BackendApi\wwwroot" + document.DocumentPath + fileName;

            using (ZipOutputStream s = new ZipOutputStream(System.IO.File.Create(tempOutPutPath)))
            {
                s.SetLevel(9); // 0-9, 9 being the highest compression

                byte[] buffer = new byte[4096];

                var ImageList = new List<string>();
                for (int i = 0; i < ImageList.Count; i++)
                {
                    ImageList.Add(@"C:\Users\DELL\WebEnterprise\WebEnterprise.BackendApi\wwwroot" + document.DocumentPath);
                }
                for (int i = 0; i < ImageList.Count; i++)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(ImageList[i]));
                    entry.DateTime = DateTime.Now;
                    entry.IsUnicodeText = true;
                    s.PutNextEntry(entry);

                    using (FileStream fs = System.IO.File.OpenRead(ImageList[i]))
                    {
                        int sourceBytes;
                        do
                        {
                            sourceBytes = fs.Read(buffer, 0, buffer.Length);
                            s.Write(buffer, 0, sourceBytes);
                        } while (sourceBytes > 0);
                    }
                }
                s.Finish();
                s.Flush();
                s.Close();
            }

            byte[] finalResult = System.IO.File.ReadAllBytes(tempOutPutPath);
            if (System.IO.File.Exists(tempOutPutPath))
                System.IO.File.Delete(tempOutPutPath);

            if (finalResult == null || !finalResult.Any())
                throw new Exception(String.Format("No Files found with Image"));

            return File(finalResult, "application/zip", fileName);
        }

        public IActionResult DownloadFileZip()
        {
            return View();
        }
    }
}
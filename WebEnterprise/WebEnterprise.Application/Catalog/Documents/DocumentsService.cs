using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using WebEnterprise.Application.Common;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Constants;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Documents
{
    public class DocumentsService : IDocumentsService
    {
        private readonly WebEnterpriseDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public DocumentsService(WebEnterpriseDbContext context, IStorageService storageService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _storageService = storageService;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<long> Create(DocumentsCreateRequest request)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var data = _context.Users.Where(p => p.Id.ToString() == userId).Select(x => x.FacultyID).FirstOrDefault();
            var document = new Document()
            {
                UserID = request.UserID,
                FacultyOfDocumentID = data,
                Status = false,
                Caption = request.Caption,
                CreateOn = DateTime.Now.Date,
                FileSize = request.DocumentFile.Length,
                DocumentPath = await this.SaveFile(request.DocumentFile),
            };
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            if (data == 1)
            {
                SystemConstants.SendMail("minhvu09033@gmail.com");
            }
            return document.ID;
        }

        public async Task<long> Update(DocumentsUpdateRequest request)
        {
            var userdocument = await _context.Documents.FindAsync(request.Id);
            if (userdocument == null)
                throw new WebEnterpriseException($"Cannot find an image with id {request.Id}");
            userdocument.Caption = request.Content;
            if (request.DocumentFile != null)
            {
                userdocument.DocumentPath = await this.SaveFile(request.DocumentFile);
                userdocument.FileSize = request.DocumentFile.Length;
            }
            _context.Documents.Update(userdocument);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> PostDocument(DocumentsPostRequest request)
        {
            var userdocument = await _context.Documents.FindAsync(request.ID);
            if (userdocument == null)
                throw new WebEnterpriseException($"Cannot find an image with id {request.ID}");
            userdocument.Status = request.Status;
            _context.Documents.Update(userdocument);
            return await _context.SaveChangesAsync();
        }

        public async Task<long> Delete(long documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null) throw new WebEnterpriseException($"Cannot find a document : {documentId}");
            _context.Documents.Remove(document);
            return await _context.SaveChangesAsync();
        }

        public async Task<DocumentsVm> GetById(long documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null)
                throw new WebEnterpriseException($"Cannot find an document with id {document}");

            var viewModel = new DocumentsVm()
            {
                Caption = document.Caption,
                CreateOn = document.CreateOn,
                FileSize = document.FileSize,
                ID = document.ID,
                DocumentPath = document.DocumentPath,
                UserID = document.UserID,
            };
            return viewModel;
        }

        public async Task<long> ViewDocument(DocumentDownloadRequest request)
        {
            var userdocument = await _context.Documents.FindAsync(request.ID);
            if (userdocument == null)
                throw new WebEnterpriseException($"Cannot find an image with id {request.ID}");
            userdocument.DocumentPath = request.DocumentPath;
            userdocument.Caption = request.Caption;
            _context.Documents.Update(userdocument);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<DocumentsVm>> GetAllPaging(GetDocumentsPagingRequest request)
        {
            var query = from c in _context.Documents
                        join u in _context.Users on c.UserID equals u.Id
                        from st in _context.SetTimeSystems
                        where (st.ID == 1)
                        select new { c, u, st };
            if (request.UserIds != null && request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserName.Contains(c.c.User.UserName));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.User.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.c.ID,
                    UserID = x.c.UserID,
                    UserName = x.u.UserName,
                    Status = x.c.Status,
                    Caption = x.c.Caption,
                    FacultyID = x.c.FacultyOfDocumentID,
                    CreateOn = x.c.CreateOn.Date,
                    StartDay = x.st.StartDay,
                    EndDay = x.st.EndDay.Date,
                }).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<DocumentsVm>> GetAllByUserId(GetDocumentsPagingRequest request)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var query = from d in _context.Documents
                        join u in _context.Users on d.UserID equals u.Id
                        join fod in _context.FacultyOfDocument on d.FacultyOfDocumentID equals fod.ID
                        from st in _context.SetTimeSystems
                        where d.UserID.ToString() == userId
                        select new { d, u, fod, st };
            if (request.DocumentId.HasValue && request.DocumentId.Value > 0)
            {
                query = query.Where(c => c.u.UserName == request.UserName);
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.d.ID,
                    UserID = x.u.Id,
                    UserName = x.u.UserName,
                    Caption = x.d.Caption,
                    FacultyName = x.fod.Name,
                    Status = x.d.Status,
                    CreateOn = x.d.CreateOn,
                    StartDay = x.st.StartDay,
                    EndDay = x.st.EndDay,
                    Daynow = DateTime.Now
                }).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<DocumentsVm>> GetAllByFaculty(GetDocumentsPagingRequest request)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var query = from d in _context.Documents
                        from u in _context.Users
                        where u.Id.ToString() == userId && d.FacultyOfDocumentID == u.FacultyID
                        select new { d, u, };
            if (request.DocumentId.HasValue && request.DocumentId.Value > 0)
            {
                query = query.Where(c => c.u.UserName == request.UserName);
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.d.ID,
                    UserID = x.u.Id,
                    UserName = x.u.UserName,
                    Caption = x.d.Caption,
                    FacultyID = x.d.FacultyOfDocumentID,
                    Status = x.d.Status,
                    CreateOn = x.d.CreateOn.Date
                }).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> RemoveDocument(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null)
                throw new WebEnterpriseException($"Cannot find an image with id {documentId}");
            _context.Documents.Remove(document);
            return await _context.SaveChangesAsync();
        }

        public async Task<DocumentsVm> GetByUserId(long documentid)
        {
            var document = await _context.Documents.FindAsync(documentid);
            var user = await (from u in _context.Users
                              join d in _context.Documents on u.Id equals d.UserID
                              select d.User.UserName).ToListAsync();

            var documentvm = new DocumentsVm()
            {
                ID = document.ID,
                UserName = document.User.UserName,
                Caption = document.Caption,
            };
            return documentvm;
        }

        public async Task<PagedResult<DocumentsVm>> GetTotal(GetDocumentsPagingRequest request)
        {
            var query = from d in _context.Documents
                        join fod in _context.FacultyOfDocument on d.FacultyOfDocumentID equals fod.ID
                        select new { d.ID, d };
            int TotalRow = await query.CountAsync();
            int Total = await query.CountAsync();
            int TotalTrue = await query.Where(x => x.d.Status == true).CountAsync();
            int TotalFalse = await query.Where(x => x.d.Status == false).CountAsync();
            int TotalIT = await query.Where(x => x.d.FacultyOfDocumentID == 1).CountAsync();
            int TotalITTrue = await query.Where(x => x.d.FacultyOfDocumentID == 1 && x.d.Status == true).CountAsync();
            int TotalITFalse = await query.Where(x => x.d.FacultyOfDocumentID == 1 && x.d.Status == false).CountAsync();
            int TotalTousrim = await query.Where(x => x.d.FacultyOfDocumentID == 2).CountAsync();
            int TotalTousrimTrue = await query.Where(x => x.d.FacultyOfDocumentID == 2 && x.d.Status == true).CountAsync();
            int TotalTousrimFalse = await query.Where(x => x.d.FacultyOfDocumentID == 2 && x.d.Status == false).CountAsync();
            int TotalDesign = await query.Where(x => x.d.FacultyOfDocumentID == 3).CountAsync();
            int TotalDesignTrue = await query.Where(x => x.d.FacultyOfDocumentID == 3 && x.d.Status == true).CountAsync();
            int TotalDesignFalse = await query.Where(x => x.d.FacultyOfDocumentID == 3 && x.d.Status == false).CountAsync();
            int TotalMarketing = await query.Where(x => x.d.FacultyOfDocumentID == 4).CountAsync();
            int TotalMarketingTrue = await query.Where(x => x.d.FacultyOfDocumentID == 4 && x.d.Status == true).CountAsync();
            int TotalMarketingFalse = await query.Where(x => x.d.FacultyOfDocumentID == 4 && x.d.Status == false).CountAsync();
            int TotalBusiness = await query.Where(x => x.d.FacultyOfDocumentID == 5).CountAsync();
            int TotalBusinessTrue = await query.Where(x => x.d.FacultyOfDocumentID == 5 && x.d.Status == true).CountAsync();
            int TotalBusinessFalse = await query.Where(x => x.d.FacultyOfDocumentID == 5 && x.d.Status == false).CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ViewCount = Total,
                    TotalTrue = TotalTrue,
                    TotalFalse = TotalFalse,
                    TotalIT = TotalIT,
                    TotalITTrue = TotalITTrue,
                    TotalITFalse = TotalITFalse,
                    TotalToursim = TotalTousrim,
                    TotalToursimTrue = TotalTousrimTrue,
                    TotalToursimFalse = TotalTousrimFalse,
                    TotalBusiness = TotalBusiness,
                    TotalBusinessTrue = TotalBusinessTrue,
                    TotalBusinessFalse = TotalBusinessFalse,
                    TotalDesign = TotalDesign,
                    TotalDesignFalse = TotalDesignFalse,
                    TotalDesignTrue = TotalDesignTrue,
                    TotalMarketing = TotalMarketing,
                    TotalMarketingFalse = TotalMarketingFalse,
                    TotalMarketingTrue = TotalMarketingTrue,
                }).Take(1).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<DocumentsVm>> GetForManager(GetDocumentsPagingRequest request)
        {
            var query = from c in _context.Documents
                        join u in _context.Users on c.UserID equals u.Id
                        where (c.Status == true)
                        select new { c, u };
            if (request.UserIds != null && request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserName.Contains(c.c.User.UserName));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.User.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.c.ID,
                    UserID = x.c.UserID,
                    UserName = x.u.UserName,
                    Status = x.c.Status,
                    Caption = x.c.Caption,
                    FacultyID = x.c.FacultyOfDocumentID,
                    CreateOn = x.c.CreateOn.Date
                }).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<DocumentsVm>> GetForGuest(GetDocumentsPagingRequest request)
        {
            var query = from c in _context.Documents
                        join u in _context.Users on c.UserID equals u.Id
                        where (c.Status == true && c.FacultyOfDocumentID == u.FacultyID)
                        select new { c, u };
            if (request.UserIds != null && request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserName.Contains(c.c.User.UserName));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.User.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.c.ID,
                    UserID = x.c.UserID,
                    UserName = x.u.UserName,
                    Status = x.c.Status,
                    Caption = x.c.Caption,
                    FacultyID = x.c.FacultyOfDocumentID,
                    CreateOn = x.c.CreateOn.Date
                }).ToListAsync();
            var pagedResult = new PagedResult<DocumentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
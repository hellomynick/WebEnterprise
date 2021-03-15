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
            var user = new User()
            {
            };
            var document = new Document()
            {
                UserID = request.UserID,
                FacultyOfDocumentID = request.FalcultyOfDocumentID,
                MagazineID = request.MagazineID,
                Caption = "Document file",
                CreateOn = DateTime.Now.Date,
            };
            if (request.DocumentFile != null)
            {
                user.Documents = new List<Document>()
                {
                    new Document()
                    {
                        Caption = "Document file",
                        CreateOn = DateTime.Now.Date,
                        FileSize = request.DocumentFile.Length,
                        DocumentPath = await this.SaveFile(request.DocumentFile),
                    }
                };
            }
            if (request.FalcultyOfDocumentID == 1)
            {
                SystemConstants.SendMail("minhvu09033@gmail.com");
            }
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return document.ID;
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

        public async Task<PagedResult<DocumentsVm>> GetAllPaging(GetDocumentsPagingRequest request)
        {
            var query = from c in _context.Documents
                        join u in _context.Users on c.UserID equals u.Id
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
                    Caption = x.c.Caption,
                    FacultyID = x.c.FacultyOfDocumentID,
                    MagazineID = x.c.MagazineID,
                    CreateOn = x.c.CreateOn.Date
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
            var query = from c in _context.Documents
                        join u in _context.Users on c.UserID equals u.Id
                        where c.UserID.ToString() == userId
                        select new { c, u };
            if (request.DocumentId.HasValue && request.DocumentId.Value > 0)
            {
                query = query.Where(c => c.u.UserName == request.UserName);
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsVm()
                {
                    ID = x.c.ID,
                    UserID = x.u.Id,
                    UserName = x.u.UserName,
                    Caption = x.c.Caption,
                    FacultyID = x.c.FacultyOfDocumentID,
                    MagazineID = x.c.MagazineID,
                    CreateOn = x.c.CreateOn.Date
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
    }
}
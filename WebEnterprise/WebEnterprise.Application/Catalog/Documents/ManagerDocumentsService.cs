using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebEnterprise.Application.Common;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Catalog.Document.Manage;

namespace WebEnterprise.Application.Catalog.Documents
{
    public class ManagerDocumentsService : IManageDocumentsService
    {
        private readonly WebEnterpriseDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-document";

        public ManagerDocumentsService(WebEnterpriseDbContext context)
        {
            _context = context;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<long> Create(Guid userId, DocumentsCreateRequest request)
        {
            var document = new Document()
            {
                Caption = request.Caption,
                CreateOn = DateTime.Now,
                UserID = userId,
            };

            if (request.DocumentFile != null)
            {
                document.DocumentPath = await this.SaveFile(request.DocumentFile);
                document.FileSize = request.DocumentFile.Length;
            }
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return document.ID;
        }

        public async Task AddViewCount(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            document.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<long> Delete(long documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null) throw new WebEnterpriseException($"Cannot find a document : {documentId}");
            _context.Documents.Remove(document);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DocumentsViewModel>> GetListDocument(Guid userId)
        {
            return await _context.Documents.Where(x => x.UserID == userId)
                .Select(i => new DocumentsViewModel()
                {
                    Caption = i.Caption,
                    CreateOn = i.CreateOn,
                    FileSize = i.FileSize,
                    ID = i.ID,
                    DocumentPath = i.DocumentPath,
                    UserID = i.UserID,
                }).ToListAsync();
        }

        public async Task<DocumentsViewModel> GetDocumentById(long documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null)
                throw new WebEnterpriseException($"Cannot find an document with id {document}");

            var viewModel = new DocumentsViewModel()
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
    }
}
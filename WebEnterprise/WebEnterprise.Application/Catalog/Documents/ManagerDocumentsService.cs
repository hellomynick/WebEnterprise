using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Catalog.Document.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Documents
{
    public class ManagerDocumentsService : IManageDocumentsService
    {
        private readonly WebEnterpriseDbContext _context;
        public ManagerDocumentsService(WebEnterpriseDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DocumentsCreateRequest request)
        {
            var document = new Document()
            {
                UserID = request.UserID,
                Name = request.Name,
                CreateOn = DateTime.Now,
                FileType = request.FileType,
                ViewCount = 0,
            };
            _context.Documents.Add(document);
            return await _context.SaveChangesAsync();
        }
        public async Task AddViewCount(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            document.ViewCount += 1;
            await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null) throw new WebEnterpriseException($"Cannot find a document : {documentId}");
            _context.Documents.Remove(document);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<DocumentsViewModel>> GetAllPaging(DocumentsPagingRequest request)
        {
            var query = from d in _context.Documents
                        join u in _context.Users on d.UserID equals u.Id
                        where d.Name.Contains(request.Keyword)
                        select new { d, u };
            if (request.UserIds.Count > 0)
            {
                query = query.Where(d => request.UserIds.Contains(d.u.Id));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.u.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DocumentsViewModel()
                {
                    ID = x.d.ID,
                    Name = x.d.Name,
                    CreateOn = x.d.CreateOn,
                    UserID = x.d.UserID,
                    FileType = x.d.FileType,
                    ViewCount = x.d.ViewCount
                }).ToListAsync();
            var pagedResult = new PageResult<DocumentsViewModel>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(DocumentsUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

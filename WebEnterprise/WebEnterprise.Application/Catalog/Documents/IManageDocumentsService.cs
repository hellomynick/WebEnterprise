using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Catalog.Document.Manage;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IManageDocumentsService
    {
        Task<long> Create(Guid userId, DocumentsCreateRequest request);

        Task<long> Delete(long documentId);

        Task<List<DocumentsViewModel>> GetListDocument(Guid userId);

        Task<DocumentsViewModel> GetDocumentById(long documentId);
    }
}
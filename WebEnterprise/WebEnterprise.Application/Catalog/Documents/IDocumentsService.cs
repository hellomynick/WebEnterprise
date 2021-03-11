using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IDocumentsService
    {
        Task<long> Create(DocumentsCreateRequest request);

        Task<long> Delete(long documentId);

        Task<PagedResult<DocumentsVm>> GetAllPaging(GetDocumentsPagingRequest request);

        Task<DocumentsVm> GetById(long documentId);

        Task<DocumentsVm> GetByUserId(long documentId);

        Task<PagedResult<DocumentsVm>> GetAllByUserId(GetDocumentsPagingRequest request);
    }
}
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

        Task<long> Update(DocumentsUpdateRequest request);

        Task<long> Delete(long documentId);

        Task<long> PostDocument(DocumentsPostRequest request);

        Task<PagedResult<DocumentsVm>> GetAllPaging(GetDocumentsPagingRequest request);

        Task<DocumentsVm> GetById(long documentId);

        Task<DocumentsVm> GetByUserId(long documentId);

        Task<PagedResult<DocumentsVm>> GetTotal(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetAllByUserId(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetAllByFaculty(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetForManager(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetForGuest(GetDocumentsPagingRequest request);

        Task<long> ViewDocument(DocumentDownloadRequest request);
    }
}
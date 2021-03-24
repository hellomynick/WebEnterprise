using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public interface IDocumentApiClient
    {
        Task<PagedResult<DocumentsVm>> GetPagings(GetDocumentsPagingRequest request);

        Task<bool> CreateDocument(DocumentsCreateRequest request);

        Task<bool> UpdateDocument(DocumentsUpdateRequest request);

        Task<PagedResult<DocumentsVm>> GetByUserID(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetByFaculty(GetDocumentsPagingRequest request);

        Task<PagedResult<DocumentsVm>> GetTotal(GetDocumentsPagingRequest request);

        Task<DocumentsVm> GetById(long id);

        Task<bool> DeleteDocument(long id);
    }
}
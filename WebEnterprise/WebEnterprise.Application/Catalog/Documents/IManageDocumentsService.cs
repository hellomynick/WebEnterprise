using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Catalog.Document.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IManageDocumentsService
    {
        Task<int> Create(DocumentsCreateRequest request);
        Task<int> Update(DocumentsUpdateRequest request);
        Task<int> Delete(int documentId);
        Task<PageResult<DocumentsViewModel>> GetAllPaging(DocumentsPagingRequest request);

    }
}

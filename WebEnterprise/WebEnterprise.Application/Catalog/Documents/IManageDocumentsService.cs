using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Documents.Dtos;
using WebEnterprise.Application.Dtos;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IManageDocumentsService
    {
        Task<int> Create(DocumentsCreateRequest request);
        Task<int> Update(DocumentsUpdateRequest request);
        Task<int> Delete(int departmentId);
        Task<List<DocumentsViewModel>> GetAll();
        Task<PageResult<DocumentsViewModel>> GetAllPaging(DocumentsPagingRequest request);

    }
}

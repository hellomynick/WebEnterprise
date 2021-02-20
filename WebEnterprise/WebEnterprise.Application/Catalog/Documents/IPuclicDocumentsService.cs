using WebEnterprise.ViewModels.Catalog.Document;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IPuclicDocumentsService
    {
        PagedResult<DocumentsViewModel> GetAllByCategoryId(int documentId, int pageIndex, int pageSize);
    }
}

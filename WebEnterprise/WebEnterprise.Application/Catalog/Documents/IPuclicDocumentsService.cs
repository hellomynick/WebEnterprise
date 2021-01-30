using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Application.Catalog.Documents.Dtos;
using WebEnterprise.Application.Dtos;

namespace WebEnterprise.Application.Catalog.Documents
{
    public interface IPuclicDocumentsService
    {
        PageResult<DocumentsViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize);
    }
}

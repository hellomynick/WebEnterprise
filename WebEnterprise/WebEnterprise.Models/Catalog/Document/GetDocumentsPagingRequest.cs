using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class GetDocumentsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserIds { get; set; }
        public string UserName { get; set; }
        public int? FacultyId { get; set; }
        public IFormFile DocumentFile { get; set; }

        public long? DocumentId { get; set; }
    }
}
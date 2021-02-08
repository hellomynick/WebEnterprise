using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Document.Manage
{
    public class DocumentsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}

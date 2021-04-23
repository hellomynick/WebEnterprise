using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Comment
{
    public class GetCommentsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string UserName { get; set; }

        public List<Guid> UserIds { get; set; }
        public long? DocumentId { get; set; }
    }
}
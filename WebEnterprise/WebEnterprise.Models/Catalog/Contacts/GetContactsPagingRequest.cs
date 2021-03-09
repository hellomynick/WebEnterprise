using System;
using System.Collections.Generic;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class GetContactsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserIds { get; set; }
        public string UserName { get; set; }
        public long? ContactId { get; set; }
    }
}
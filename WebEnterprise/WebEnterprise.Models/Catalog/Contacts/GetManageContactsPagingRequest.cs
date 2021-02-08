using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class GetManageContactsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserIds { get; set; }
        public int? ContactId { get; set; }
    }
}

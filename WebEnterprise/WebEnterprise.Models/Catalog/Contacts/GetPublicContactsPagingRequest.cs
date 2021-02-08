using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class GetPublicContactsPagingRequest : PagingRequestBase
    {
        public int? ContactId { get; set; }
    }
}

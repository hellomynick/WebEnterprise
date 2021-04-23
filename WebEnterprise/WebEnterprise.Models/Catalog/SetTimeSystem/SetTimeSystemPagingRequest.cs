using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.SetTimeSystem
{
    public class SetTimeSystemPagingRequest : PagingRequestBase
    {
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
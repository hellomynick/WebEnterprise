using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Positions
{
    public class GetPositionsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserIds { get; set; }
        public string UserName { get; set; }
        public int? PositionID { get; set; }
    }
}
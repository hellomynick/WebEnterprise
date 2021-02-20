using System;
using System.Collections.Generic;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.SchoolYears.Manage
{
    public class GetManageSchoolYearsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.Facultys.Manage
{
    public class GetManageFacultysPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> FacultiesID { get; set; }
    }
}

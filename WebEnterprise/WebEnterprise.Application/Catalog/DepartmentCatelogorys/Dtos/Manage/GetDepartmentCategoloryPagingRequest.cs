using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Application.Dtos;

namespace WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos
{
    public class DocumentsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> UserIds { get; set; }
    }
}

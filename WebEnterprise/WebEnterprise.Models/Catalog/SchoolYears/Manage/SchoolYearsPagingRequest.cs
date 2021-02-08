﻿using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.Catalog.SchoolYears.Manage
{
    public class SchoolYearsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<Guid> UserID { get; set; }
    }
}

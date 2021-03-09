using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class RequestDocumentViewModel
    {
        public string UserName { get; set; }

        public string Faculty { get; set; }

        public List<DocumentsVm> OrderDetails { set; get; } = new List<DocumentsVm>();
    }
}
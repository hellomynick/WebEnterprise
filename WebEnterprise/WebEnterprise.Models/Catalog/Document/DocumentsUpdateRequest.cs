using Microsoft.AspNetCore.Http;
using System;

namespace WebEnterprise.ViewModels.Catalog.Document.Manage
{
    public class DocumentsUpdateRequest
    {
        public long ID { get; set; }
        public string Caption { get; set; }
        public DateTime CreateOn { set; get; }
        public IFormFile DocumentFile { get; set; }
    }
}
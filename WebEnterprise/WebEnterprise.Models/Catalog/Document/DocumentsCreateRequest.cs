using Microsoft.AspNetCore.Http;
using System;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsCreateRequest
    {
        public long ID { get; set; }
        public string Caption { get; set; }
        public Guid UserID { set; get; }
        public IFormFile DocumentFile { get; set; }
    }
}
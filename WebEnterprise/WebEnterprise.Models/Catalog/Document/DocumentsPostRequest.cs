using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsPostRequest
    {
        public long ID { get; set; }
        public bool Status { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
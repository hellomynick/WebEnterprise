using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsUpdateRequest
    {
        public long Id { get; set; }
        public IFormFile DocumentFile { get; set; }
    }
}
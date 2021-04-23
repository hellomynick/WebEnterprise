using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentDownloadRequest
    {
        public long ID { get; set; }
        public string DocumentPath { get; set; }
        public string Caption { get; set; }
    }
}
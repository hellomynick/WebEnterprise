using System;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsViewModel
    {
        public long ID { get; set; }
        public Guid UserID { set; get; }
        public string DocumentPath { get; set; }
        public string Caption { get; set; }
        public int ViewCount { get; set; }
        public long FileSize { get; set; }
        public DateTime CreateOn { set; get; }
    }
}
using System;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsVm
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public Guid UserID { get; set; }
        public string DocumentPath { get; set; }
        public int MagazineID { get; set; }
        public int FacultyID { get; set; }
        public string Caption { get; set; }
        public int ViewCount { get; set; }
        public long FileSize { get; set; }
        public DateTime CreateOn { set; get; }
    }
}
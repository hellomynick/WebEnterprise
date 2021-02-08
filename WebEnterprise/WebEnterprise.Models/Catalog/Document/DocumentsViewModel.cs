using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Document
{
    public class DocumentsViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public Guid UserID { set; get; }
        public string FileType { set; get; }
        public int ViewCount { get; set; }
        public DateTime CreateOn { set; get; }


    }
}

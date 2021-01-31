using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Application.Catalog.Documents.Dtos
{
    public class DocumentsCreateRequest
    {
        public string Name { get; set; }
        public Guid UserID { set; get; }
        public string FileType { set; get; }
        public string DateFile { set; get; }
        public DateTime CreateOn { set; get; }
    }
}

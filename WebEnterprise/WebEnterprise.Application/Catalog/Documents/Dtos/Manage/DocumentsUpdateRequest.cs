using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Application.Catalog.Documents.Dtos
{
    public class DocumentsUpdateRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FileType { set; get; }
        public string DateFile { set; get; }
        public DateTime CreateOn { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class DocumentInDepartment
    {
        public long ID { get; set; }
        public long DocumentID { get; set; }
        public long DepartmentCategoloryID { get; set; }
        public List<Document> Documents { get; set; }
        public DepartmentCatelogory DepartmentCatelogorys { get; set; }
    }
}

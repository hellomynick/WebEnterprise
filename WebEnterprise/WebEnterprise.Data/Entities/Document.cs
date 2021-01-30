using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Document
    {
        public long ID { set; get; }
        public string Name { set; get; }
        public Guid UserID { set; get; }
        public string FileType { set; get; }
        public string DateFile { set; get; }
        public DateTime CreateOn { set; get; }
        public int DepartmentCatelogoryID { get; set; }
        public User User { get; set; }
        public Megazine Megazines { get; set; }
        public DepartmentCatelogory DepartmentCatelogorys { get; set; }

    }
}

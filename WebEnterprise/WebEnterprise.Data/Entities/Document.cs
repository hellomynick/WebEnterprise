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
        public byte[] DataFile { set; get; }
        public int ViewCount { get; set; }
        public int MagazineID { get; set; }
        public DateTime CreateOn { set; get; }
        public User User { get; set; }
        public int FacultyOfDocumentID { get; set; }
        public FacultyOfDocument FacultyOfDocuments { get; set; }
        public Magazine Magazines { get; set; }
    }
}

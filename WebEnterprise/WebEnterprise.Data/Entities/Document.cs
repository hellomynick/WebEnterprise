using System;
using System.ComponentModel.DataAnnotations;

namespace WebEnterprise.Data.Entities
{
    public class Document
    {
        public long ID { set; get; }

        public Guid UserID { set; get; }
        public string DocumentPath { get; set; }
        public string Caption { get; set; }
        public long FileSize { get; set; }
        public int ViewCount { get; set; }
        public int MagazineID { get; set; }
        public DateTime CreateOn { set; get; }
        public User User { get; set; }
        public int FacultyOfDocumentID { get; set; }
        public FacultyOfDocument FacultyOfDocuments { get; set; }
        public Magazine Magazines { get; set; }
    }
}
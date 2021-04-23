using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public Guid? UserID { get; set; }
        public long? DocumentID { get; set; }
        public string Content { get; set; }
        public Document Documents { get; set; }
        public User Users { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Comment
    {
        public long ID { set; get; }
        public Guid UserID { set; get; }
        public long CreateOn { set; get; }
        public User Users { get; set; }
    }
}

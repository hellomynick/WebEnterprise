using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class DepartmentCatelogory
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public Guid UserID { set; get; }
        public User Users { get; set; }
        public List<Document> Documents { get; set; }
    }
}

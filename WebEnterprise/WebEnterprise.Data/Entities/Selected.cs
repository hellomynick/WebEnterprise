using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Selected
    {
        public long ID { set; get; }
        public string Name { set; get; }
        public long DocumentID { set; get; }
        public List<Document> Documents { get; set; }
    }
}

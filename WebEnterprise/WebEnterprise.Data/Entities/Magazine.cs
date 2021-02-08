using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Magazine
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public List<Document> Documents { get; set; }
    }
}

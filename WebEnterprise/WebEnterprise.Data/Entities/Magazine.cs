using System.Collections.Generic;

namespace WebEnterprise.Data.Entities
{
    public class Magazine
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public List<Document> Documents { get; set; }
    }
}

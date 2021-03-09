using System.Collections.Generic;

namespace WebEnterprise.Data.Entities
{
    public class FacultyOfDocument
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Document> Documents { get; set; }
    }
}
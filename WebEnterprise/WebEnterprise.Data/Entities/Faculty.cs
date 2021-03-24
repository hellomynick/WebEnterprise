using System.Collections.Generic;

namespace WebEnterprise.Data.Entities
{
    public class Faculty
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public List<User> Users { get; set; }
    }
}
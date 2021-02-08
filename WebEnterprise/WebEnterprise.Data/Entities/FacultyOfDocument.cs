using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class FacultyOfDocument
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Document Documents { get; set; }
    }
}

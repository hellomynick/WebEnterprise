using System;

namespace WebEnterprise.Data.Entities
{
    public class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FacultyID { get; set; }
        public Guid UserID { get; set; }
        public User Users { get; set; }
        public Faculty Faculties { get; set; }
    }
}
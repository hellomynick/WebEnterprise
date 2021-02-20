using System;

namespace WebEnterprise.Data.Entities
{
    public class SchoolYear
    {
        public int ID { set; get; }
        public Guid UserID { set; get; }
        public DateTime StartDayYear { set; get; }
        public DateTime EndDayYear { set; get; }
        public User Users { get; set; }

    }
}

using System;

namespace WebEnterprise.ViewModels.Catalog.SchoolYears.Manage
{
    public class SchoolYearsUpdateRequest
    {
        public int ID { set; get; }
        public Guid UserID { set; get; }
        public DateTime StartDayYear { set; get; }
        public DateTime EndDayYear { set; get; }
    }
}

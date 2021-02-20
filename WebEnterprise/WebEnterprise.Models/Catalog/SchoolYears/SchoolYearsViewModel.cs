using System;

namespace WebEnterprise.ViewModels.Catalog.SchoolYears
{
    public class SchoolYearsViewModel
    {
        public int ID { set; get; }
        public Guid UserID { set; get; }
        public DateTime StartDayYear { set; get; }
        public DateTime EndDayYear { set; get; }
    }
}

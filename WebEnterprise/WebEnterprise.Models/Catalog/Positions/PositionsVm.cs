using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Positions
{
    public class PositionsVm
    {
        public int ID { get; set; }
        public int FacultyID { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
    }
}
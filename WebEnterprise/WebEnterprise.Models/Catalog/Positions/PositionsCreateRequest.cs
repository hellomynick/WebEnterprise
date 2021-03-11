using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Positions
{
    public class PositionsCreateRequest
    {
        public string Name { get; set; }
        public int FacultyID { get; set; }
        public Guid UserID { get; set; }
    }
}
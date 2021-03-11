using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Positions
{
    public class PositionsUpdateRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FacultyID { get; set; }
    }
}
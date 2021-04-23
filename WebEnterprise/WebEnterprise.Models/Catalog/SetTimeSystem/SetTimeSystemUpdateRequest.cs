using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.SetTimeSystem
{
    public class SetTimeSystemUpdateRequest
    {
        public int Id { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
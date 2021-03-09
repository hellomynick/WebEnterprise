using System;
using System.Collections.Generic;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class ContactsVm
    {
        public long ID { set; get; }
        public string UserName { get; set; }
        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public int TotalOfDocument { set; get; }
        public Guid UserIds { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class ContactsUpdateRequest
    {
        public int ID { get; set; }
        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public int TotalOfDocument { set; get; }
        public IFormFile ThumbnailImage { get; set; }
    }
}

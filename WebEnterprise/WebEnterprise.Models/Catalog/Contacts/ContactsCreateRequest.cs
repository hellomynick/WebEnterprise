using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class ContactsCreateRequest
    {

        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public int TotalOfDocument { set; get; }
        public IFormFile ThumbnailImage { get; set; }

    }
}

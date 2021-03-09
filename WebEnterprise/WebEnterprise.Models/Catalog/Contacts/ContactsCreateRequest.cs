using Microsoft.AspNetCore.Http;
using System;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class ContactsCreateRequest
    {
        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public Guid UserID { get; set; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
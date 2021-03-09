using Microsoft.AspNetCore.Http;

namespace WebEnterprise.ViewModels.Catalog.Contacts
{
    public class ContactsUpdateRequest
    {
        public long ID { get; set; }
        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public int TotalOfDocument { set; get; }
        public IFormFile ThumbnailImage { get; set; }
    }
}
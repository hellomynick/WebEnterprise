using System;
using System.Collections.Generic;

namespace WebEnterprise.Data.Entities
{
    public class Contact
    {
        public long ID { set; get; }
        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public int TotalofDocument { get; set; }
        public Guid UserID { get; set; }
        public User Users { get; set; }
        public List<UserImage> UserImages { get; set; }
    }
}
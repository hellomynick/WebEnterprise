using System;

namespace WebEnterprise.Data.Entities
{
    public class UserImage
    {
        public int ID { get; set; }
        public long ContactID { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DayCreated { get; set; }
        public long FileSize { get; set; }
        public Contact Contacts { get; set; }
    }
}
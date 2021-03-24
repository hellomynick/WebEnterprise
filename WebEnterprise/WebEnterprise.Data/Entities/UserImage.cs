using System;

namespace WebEnterprise.Data.Entities
{
    public class UserImage
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DayCreated { get; set; }
        public long FileSize { get; set; }
        public User Users { get; set; }
    }
}
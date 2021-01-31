using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class Contact
    {
        public long ID { set; get; }

        public string ApartmentNumber { set; get; }
        public string NameStreet { set; get; }
        public byte[] Image { set; get; }

        public User Users { get; set; }

    }
}

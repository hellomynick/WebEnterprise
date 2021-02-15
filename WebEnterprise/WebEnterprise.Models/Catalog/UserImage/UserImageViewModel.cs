using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.UserImage
{
    public class UserImageViewModel
    {
        public int ID { get; set; }

        public long ContactID { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime DateCreated { get; set; }

        public long FileSize { get; set; }
    }
}

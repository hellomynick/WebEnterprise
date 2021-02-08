﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
        public bool Sex { set; get; }
        public int FacultyID { set; get; }
        public long ContactID { set; get; }
        public DateTime CreateOn { set; get; }
        public List<Document> Documents { get; set; }
        public Contact Contacts { get; set; }
        public List<SchoolYear> SchoolYears { get; set; }
        public Faculty Faculties { get; set; }

    }
}

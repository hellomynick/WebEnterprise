using System;

namespace WebEnterprise.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime DateOfBirth { set; get; }
        public bool Sex { set; get; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
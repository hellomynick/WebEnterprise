using Microsoft.AspNetCore.Http;

namespace WebEnterprise.ViewModels.Catalog.UserImage
{
    public class UserImageUpdateRequest
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}

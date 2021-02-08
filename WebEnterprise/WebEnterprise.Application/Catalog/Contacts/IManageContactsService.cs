using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Contacts
{
    public interface IManageContactsService
    {
        Task<int> Create(ContactsCreateRequest request);
        Task<int> Update(ContactsUpdateRequest request);
        Task<int> Delete(int contactId);
        Task TotalOfDocument(int documentId);
        Task<PageResult<ContactsViewModel>> GetAllPaging(GetManageContactsPagingRequest request);
        Task<int> AddImages(int contactId, List<IFormFile> files);
        Task<int> RemoveImages(int contactId);
        Task<int> UpdateImages(int contactId, bool isDefault);
        Task<List<UserImageViewModel>> GetListImage(int contactId);


    }
}

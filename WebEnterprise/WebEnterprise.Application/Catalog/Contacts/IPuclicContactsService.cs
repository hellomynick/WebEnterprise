using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Contacts
{
    public interface IPuclicContactsService
    {
        Task<PageResult<ContactsViewModel>> GetAllByUserId(GetPublicContactsPagingRequest request);
    }
}

﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Catalog.UserImage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Contacts
{
    public interface IManageContactsService
    {
        Task<long> Create(ContactsCreateRequest request);
        Task<long> Update(ContactsUpdateRequest request);
        Task<long> Delete(long contactId);
        Task<ContactsViewModel> GetById(long contactId);
        Task TotalOfDocument(long documentId);
        Task<PageResult<ContactsViewModel>> GetAllPaging(GetManageContactsPagingRequest request);
        Task<int> AddImage(long contactId, UserImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, UserImageUpdateRequest request);
        Task<List<UserImageViewModel>> GetListImages(long contactId);
        Task<UserImageViewModel> GetImageById(int imageId);

    }
}

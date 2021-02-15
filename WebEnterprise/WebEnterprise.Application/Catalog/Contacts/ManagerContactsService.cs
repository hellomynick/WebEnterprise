﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Common;
using System.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Http;
using WebEnterprise.Application.Common;
using WebEnterprise.ViewModels.Catalog.UserImage;

namespace WebEnterprise.Application.Catalog.Contacts
{
    public class ManagerContactsService : IManageContactsService
    {
        private readonly WebEnterpriseDbContext _context;
        private readonly IStorageService _storageService;

        public ManagerContactsService(WebEnterpriseDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task TotalOfDocument(long documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            document.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<long> Create(ContactsCreateRequest request)
        {
            var contact = new Contact()
            {
                ApartmentNumber = request.ApartmentNumber,
                TotalofDocument = request.TotalOfDocument,
                NameStreet = request.NameStreet,
            };
            if (request.ThumbnailImage != null)
            {
                contact.UserImages = new List<UserImage>()
                {
                    new UserImage()
                    {
                        Caption = "Thumbnail image",
                        DayCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                    }
                };
            }
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact.ID;
        }

        public async Task<long> Update(ContactsUpdateRequest request)
        {
            var contact = await _context.Contacts.FindAsync(request.ID);
            contact.ApartmentNumber = request.ApartmentNumber;
            contact.NameStreet = request.NameStreet;
            contact.TotalofDocument = request.TotalOfDocument;
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.UserImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ContactID == request.ID);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.UserImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<long> Delete(long contactId)
        {
            var contact = await _context.Documents.FindAsync(contactId);
            if (contact == null) throw new WebEnterpriseException($"Cannot find a contact : {contactId}");
            var images = _context.UserImages.Where(i => i.ContactID == contactId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Documents.Remove(contact);
            return await _context.SaveChangesAsync();
        }

        public async Task<PageResult<ContactsViewModel>> GetAllPaging(GetManageContactsPagingRequest request)
        {
            var query = from c in _context.Contacts
                        join u in _context.Users on c.UserID equals u.Id
                        select new { c, u };
            if (request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserIds.Contains(c.c.Users.Id));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.Users.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ContactsViewModel()
                {
                    ID = x.c.ID,
                    ApartmentNumber = x.c.ApartmentNumber,
                    NameStreet = x.c.NameStreet,
                    TotalOfDocument = x.c.TotalofDocument
                }).ToListAsync();
            var pagedResult = new PageResult<ContactsViewModel>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ContactsViewModel> GetById(long contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);
            var contactsViewModel = new ContactsViewModel()
            {
                ID = contact.ID,
                ApartmentNumber = contact.ApartmentNumber,
                NameStreet = contact.NameStreet
            };
            return contactsViewModel;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> AddImage(long contactId, UserImageCreateRequest request)
        {
            var userImage = new UserImage()
            {
                Caption = request.Caption,
                DayCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ContactID = contactId,
            };

            if (request.ImageFile != null)
            {
                userImage.ImagePath = await this.SaveFile(request.ImageFile);
                userImage.FileSize = request.ImageFile.Length;
            }
            _context.UserImages.Add(userImage);
            await _context.SaveChangesAsync();
            return userImage.ID;
        }

        public async Task<int> UpdateImage(int imageId, UserImageUpdateRequest request)
        {
            var userImage = await _context.UserImages.FindAsync(imageId);
            if (userImage == null)
                throw new WebEnterpriseException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                userImage.ImagePath = await this.SaveFile(request.ImageFile);
                userImage.FileSize = request.ImageFile.Length;
            }
            _context.UserImages.Update(userImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var userImage = await _context.UserImages.FindAsync(imageId);
            if (userImage == null)
                throw new WebEnterpriseException($"Cannot find an image with id {imageId}");
            _context.UserImages.Remove(userImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<UserImageViewModel>> GetListImages(long contactId)
        {
            return await _context.UserImages.Where(x => x.ContactID == contactId)
                .Select(i => new UserImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DayCreated,
                    FileSize = i.FileSize,
                    ID = i.ID,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ContactID = i.ContactID,
                }).ToListAsync();
        }

        public async Task<UserImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.UserImages.FindAsync(imageId);
            if (image == null)
                throw new WebEnterpriseException($"Cannot find an image with id {imageId}");

            var viewModel = new UserImageViewModel()
            {
                Caption = image.Caption,
                DateCreated = image.DayCreated,
                FileSize = image.FileSize,
                ID = image.ID,
                ImagePath = image.ImagePath,
                IsDefault = image.IsDefault,
                ContactID = image.ContactID,
            };
            return viewModel;
        }
    }
}
using System;
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
        public async Task TotalOfDocument(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);
            document.ViewCount += 1;
            await _context.SaveChangesAsync();
        }
        public async Task<int> Create(ContactsCreateRequest request)
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
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int contactId)
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
                        join u in _context.Users on c.ID equals u.ContactID
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

        public async Task<int> Update(ContactsUpdateRequest request)
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

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public Task<int> AddImages(int contactId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveImages(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImages(int contactId, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserImageViewModel>> GetListImage(int contactId)
        {
            throw new NotImplementedException();
        }
    }
}

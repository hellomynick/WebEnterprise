using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.ViewModels.Catalog.Contacts;
using WebEnterprise.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebEnterprise.Application.Catalog.Contacts
{
    public class PublicContactsService : IPuclicContactsService
    {
        private readonly WebEnterpriseDbContext _context;
        public PublicContactsService(WebEnterpriseDbContext context)
        {
            _context = context;
        }
        public async Task<PageResult<ContactsViewModel>> GetAllByCategoryId(GetPublicContactsPagingRequest request)
        {
            var query = from c in _context.Contacts
                        join u in _context.Users on c.ID equals u.ContactID
                        select new { c, u };
            if (request.ContactId.HasValue && request.ContactId.Value > 0)
            {
                query = query.Where(c => c.u.ContactID == request.ContactId);
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
    }
}

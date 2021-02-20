using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Facultys;
using WebEnterprise.ViewModels.Catalog.Facultys.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Facultys
{
    public class ManagerFacultysService : IManageFacultysService
    {
        private readonly WebEnterpriseDbContext _context;

        public ManagerFacultysService(WebEnterpriseDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(FacultysCreateRequest request)
        {
            var faculty = new Faculty()
            {
                Name = request.Name,
            };
            _context.Faculties.Add(faculty);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int facultyId)
        {
            var faculty = await _context.Documents.FindAsync(facultyId);
            if (faculty == null) throw new WebEnterpriseException($"Cannot find a contact : {facultyId}");
            _context.Documents.Remove(faculty);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<FacultysViewModel>> GetAllPaging(GetManageFacultysPagingRequest request)
        {
            var query = from f in _context.Faculties
                        join p in _context.Positions on f.ID equals p.FacultyID
                        join u in _context.Users on p.UserID equals u.Id
                        select new { f, p, u };
            if (request.FacultiesID.Count > 0)
            {
                query = query.Where(f => request.FacultiesID.Contains(f.f.ID));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.u.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new FacultysViewModel()
                {
                    ID = x.f.ID,
                    Name = x.f.Name
                }).ToListAsync();
            var pagedResult = new PagedResult<FacultysViewModel>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(FacultysUpdateRequest request)
        {
            var contact = _context.Faculties.Find(request.ID);
            contact.Name = request.Name;
            return await _context.SaveChangesAsync();
        }
    }
}
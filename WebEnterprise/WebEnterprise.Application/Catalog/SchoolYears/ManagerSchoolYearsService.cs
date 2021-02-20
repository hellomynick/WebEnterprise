using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.SchoolYears;
using WebEnterprise.ViewModels.Catalog.SchoolYears.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.SchoolYears
{
    public class ManagerContactsService : IManageSchoolYearsService
    {
        private readonly WebEnterpriseDbContext _context;
        public ManagerContactsService(WebEnterpriseDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(SchoolYearsCreateRequest request)
        {
            var schoolYear = new SchoolYear()
            {
                UserID = request.UserID,
                StartDayYear = request.StartDayYear,
                EndDayYear = request.EndDayYear
            };
            _context.SchoolYears.Add(schoolYear);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int schoolYearId)
        {
            var schoolYear = await _context.SchoolYears.FindAsync(schoolYearId);
            if (schoolYear == null) throw new WebEnterpriseException($"Cannot find a contact : {schoolYearId}");
            _context.SchoolYears.Remove(schoolYear);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<SchoolYearsViewModel>> GetAllPaging(GetManageSchoolYearsPagingRequest request)
        {
            var query = from c in _context.SchoolYears
                        where c.Users.UserName.Contains(request.Keyword)
                        select new { c, };
            if (request.UserID.Count > 0)
            {
                query = query.Where(c => request.UserID.Contains(c.c.Users.Id));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.Users.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SchoolYearsViewModel()
                {
                    ID = x.c.ID,
                    StartDayYear = x.c.StartDayYear,
                    EndDayYear = x.c.EndDayYear,
                }).ToListAsync();
            var pagedResult = new PagedResult<SchoolYearsViewModel>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(SchoolYearsUpdateRequest request)
        {
            var schollYear = _context.SchoolYears.Find(request.ID);
            schollYear.StartDayYear = request.StartDayYear;
            schollYear.EndDayYear = request.EndDayYear;
            schollYear.UserID = request.UserID;
            return await _context.SaveChangesAsync();
        }
    }
}

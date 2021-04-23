using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Data.Entities;
using WebEnterprise.Data.EF;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebEnterprise.Application.Catalog.SetTimeSystems
{
    public class SetTimeSystemService : ISetTimeSystemService
    {
        private readonly WebEnterpriseDbContext _context;

        public SetTimeSystemService(WebEnterpriseDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(SetTimeSystemCreateRequest request)
        {
            var settime = new SetTimeSystem()
            {
                StartDay = request.StartDay,
                EndDay = request.EndDay
            };
            _context.SetTimeSystems.Add(settime);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var settime = await _context.SetTimeSystems.FindAsync(id);
            if (settime == null) throw new WebEnterpriseException($"Cannot find a time : {id}");
            _context.SetTimeSystems.Remove(settime);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(SetTimeSystemUpdateRequest request)
        {
            var settime = await _context.SetTimeSystems.FindAsync(request.Id);
            if (settime == null)
                throw new WebEnterpriseException($"Cannot find an time with id {request.Id}");
            settime.StartDay = request.StartDay;
            settime.EndDay = request.EndDay;
            _context.SetTimeSystems.Update(settime);
            return await _context.SaveChangesAsync();
        }

        public async Task<SetTimeSystemVm> GetById(int id)
        {
            var settime = await _context.SetTimeSystems.FindAsync(id);
            if (settime == null)
                throw new WebEnterpriseException($"Cannot find an document with id {settime}");

            var viewModel = new SetTimeSystemVm()
            {
                ID = settime.ID,

                StartDay = settime.StartDay,
                EndDay = settime.EndDay
            };
            return viewModel;
        }

        public async Task<PagedResult<SetTimeSystemVm>> GetAllPaging(SetTimeSystemPagingRequest request)
        {
            var query = from st in _context.SetTimeSystems
                        select new { st };
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SetTimeSystemVm()
                {
                    ID = x.st.ID,
                    StartDay = x.st.StartDay,
                    EndDay = x.st.EndDay.Date,
                }).ToListAsync();
            var pagedResult = new PagedResult<SetTimeSystemVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
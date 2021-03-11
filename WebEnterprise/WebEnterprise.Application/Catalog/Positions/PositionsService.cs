using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Positions;
using WebEnterprise.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebEnterprise.Application.Catalog.Positions
{
    public class PositionsService : IPositionsService
    {
        private readonly WebEnterpriseDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PositionsService(WebEnterpriseDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<int> Create(PositionsCreateRequest request)
        {
            var position = new Position()
            {
                Name = request.Name,
                FacultyID = request.FacultyID,
                UserID = request.UserID
            };
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position.ID;
        }

        public async Task<int> Delete(int positionId)
        {
            var position = await _context.Positions.FindAsync(positionId);
            if (position == null) throw new WebEnterpriseException($"Cannot find a position : {positionId}");
            _context.Positions.Remove(position);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(PositionsUpdateRequest request)
        {
            var position = await _context.Positions.FindAsync(request.ID);
            position.Name = request.Name;
            position.FacultyID = request.FacultyID;
            return await _context.SaveChangesAsync();
        }

        public async Task<PositionsVm> GetById(int PositionsId)
        {
            var position = await _context.Positions.FindAsync(PositionsId);
            var positionVm = new PositionsVm()
            {
                ID = position.ID,
                Name = position.Name,
                FacultyID = position.FacultyID,
                UserID = position.UserID,
            };
            return positionVm;
        }

        public async Task<PagedResult<PositionsVm>> GetAllPaging(GetPositionsPagingRequest request)
        {
            var query = from p in _context.Positions
                        join f in _context.Faculties on p.FacultyID equals f.ID
                        join u in _context.Users on p.UserID equals u.Id
                        select new { p, u, f };
            if (request.UserIds != null && request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserName.Contains(c.p.Users.UserName));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.Users.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PositionsVm()
                {
                    ID = x.p.ID,
                    Name = x.p.Name,
                    UserID = x.p.UserID,
                    UserName = x.u.UserName,
                    Faculty = x.f.Name
                }).ToListAsync();
            var pagedResult = new PagedResult<PositionsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<PositionsVm>> GetAllByUserId(GetPositionsPagingRequest request)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var query = from p in _context.Positions
                        join f in _context.Faculties on p.FacultyID equals f.ID
                        join u in _context.Users on p.UserID equals u.Id
                        where p.UserID.ToString() == userId
                        select new { p, u, f };
            if (request.PositionID.HasValue && request.PositionID.Value > 0)
            {
                query = query.Where(c => c.u.UserName == request.UserName);
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PositionsVm()
                {
                    ID = x.p.ID,
                    UserID = x.u.Id,
                    UserName = x.u.UserName,
                    Faculty = x.f.Name,
                }).ToListAsync();
            var pagedResult = new PagedResult<PositionsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
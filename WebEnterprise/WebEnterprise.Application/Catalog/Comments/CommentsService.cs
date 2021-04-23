using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;
using WebEnterprise.Untilities.Exceptions;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using WebEnterprise.Untilities.Constants;

namespace WebEnterprise.Application.Catalog.Comments
{
    public class CommentsService : ICommentsService
    {
        private readonly WebEnterpriseDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentsService(WebEnterpriseDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Create(CommentsCreateRequest request)
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString();
            var data = _context.Users.Where(p => p.Id.ToString() == userId).Select(x => x.FacultyID).FirstOrDefault();
            var data1 = _context.Users.Where(p => p.FacultyID == 1).Select(x => x.Email).FirstOrDefault();
            var data2 = _context.Roles.Select(x => x.Name).FirstOrDefault();
            var comment = new Comment()
            {
                UserID = request.UserID,
                Content = request.Content,
                DocumentID = request.DocumentID
            };
            if (data == 1 && data2 == "student")
            {
                SystemConstants.SendMail(data1);
            }
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment.ID;
        }

        public async Task<int> Delete(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null) throw new WebEnterpriseException($"Cannot find a document : {commentId}");
            _context.Comments.Remove(comment);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(CommentsUpdateRequest request)
        {
            var usercomment = await _context.Comments.FindAsync(request.ID);
            if (usercomment == null)
                throw new WebEnterpriseException($"Cannot find an image with id {request.ID}");
            usercomment.Content = request.Content;
            _context.Comments.Update(usercomment);
            return await _context.SaveChangesAsync();
        }

        public async Task<CommentsVm> GetById(int documentId)
        {
            var document = await _context.Comments.FindAsync(documentId);
            if (document == null)
                throw new WebEnterpriseException($"Cannot find an document with id {document}");

            var viewModel = new CommentsVm()
            {
                Content = document.Content,
                UserId = document.UserID,
                DocumentId = document.DocumentID,
                ID = document.ID,
            };
            return viewModel;
        }

        public async Task<PagedResult<CommentsVm>> GetAllPaging(GetCommentsPagingRequest request)
        {
            var query = from c in _context.Comments
                        join u in _context.Users on c.UserID equals u.Id
                        join d in _context.Documents on c.DocumentID equals d.ID
                        where c.DocumentID == d.ID
                        select new { c, u, d };
            if (request.UserIds != null && request.UserIds.Count > 0)
            {
                query = query.Where(c => request.UserName.Contains(c.c.Users.UserName));
            }
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.c.Users.UserName.Contains(request.Keyword));
            }
            int TotalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CommentsVm()
                {
                    ID = x.c.ID,
                    Content = x.c.Content,
                    DocumentId = x.c.DocumentID,
                    UserId = x.c.UserID
                }).ToListAsync();
            var pagedResult = new PagedResult<CommentsVm>()
            {
                TotalRecord = TotalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
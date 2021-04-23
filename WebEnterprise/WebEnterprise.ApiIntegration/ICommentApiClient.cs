using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public interface ICommentApiClient
    {
        Task<PagedResult<CommentsVm>> GetPagings(GetCommentsPagingRequest request);

        Task<bool> CreateComment(CommentsCreateRequest request);

        Task<bool> UpdateComment(CommentsUpdateRequest request);

        Task<CommentsVm> GetById(int id);

        Task<bool> DeleteComment(int id);
    }
}
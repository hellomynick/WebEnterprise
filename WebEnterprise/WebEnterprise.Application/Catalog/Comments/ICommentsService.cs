using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Comments
{
    public interface ICommentsService
    {
        Task<int> Create(CommentsCreateRequest request);

        Task<int> Update(CommentsUpdateRequest request);

        Task<PagedResult<CommentsVm>> GetAllPaging(GetCommentsPagingRequest request);

        Task<CommentsVm> GetById(int documentId);

        Task<int> Delete(int commentId);
    }
}
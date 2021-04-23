using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Comment;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Models
{
    public class CommentViewModel
    {
        public CommentsCreateRequest Createcomment { get; set; }
        public PagedResult<CommentsVm> Comments { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Comment
{
    public class CommentsCreateRequest
    {
        public Guid UserID { get; set; }
        public long DocumentID { get; set; }
        public string Content { get; set; }
    }
}
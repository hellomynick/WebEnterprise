using System;
using System.Collections.Generic;
using System.Text;

namespace WebEnterprise.ViewModels.Catalog.Comment
{
    public class CommentsVm
    {
        public int ID { get; set; }
        public Guid? UserId { get; set; }
        public string Content { get; set; }
        public long? DocumentId { get; set; }
    }
}
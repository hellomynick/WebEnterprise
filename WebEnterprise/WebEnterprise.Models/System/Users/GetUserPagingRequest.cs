using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
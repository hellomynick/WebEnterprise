using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Common;
using WebEnterprise.ViewModels.System.Roles;

namespace WebEnterprise.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVm>>> GetAll();
    }
}
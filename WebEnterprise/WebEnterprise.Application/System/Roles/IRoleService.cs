using System.Collections.Generic;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.System.Roles;

namespace WebEnterprise.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
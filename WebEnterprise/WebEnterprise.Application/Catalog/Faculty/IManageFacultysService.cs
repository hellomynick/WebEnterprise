using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Facultys;
using WebEnterprise.ViewModels.Catalog.Facultys.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Facultys
{
    public interface IManageFacultysService
    {
        Task<int> Create(FacultysCreateRequest request);
        Task<int> Update(FacultysUpdateRequest request);
        Task<int> Delete(int facultyId);
        Task<PagedResult<FacultysViewModel>> GetAllPaging(GetManageFacultysPagingRequest request);

    }
}

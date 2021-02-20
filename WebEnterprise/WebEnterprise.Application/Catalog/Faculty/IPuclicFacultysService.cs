using WebEnterprise.ViewModels.Catalog.Facultys;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Facultys
{
    public interface IPuclicFacultysService
    {
        PagedResult<FacultysViewModel> GetAllByCategoryId(int FacultyId, int pageIndex, int pageSize);
    }
}

using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.SchoolYears;
using WebEnterprise.ViewModels.Catalog.SchoolYears.Manage;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.SchoolYears
{
    public interface IManageSchoolYearsService
    {
        Task<int> Create(SchoolYearsCreateRequest request);
        Task<int> Update(SchoolYearsUpdateRequest request);
        Task<int> Delete(int schoolyearId);
        Task<PagedResult<SchoolYearsViewModel>> GetAllPaging(GetManageSchoolYearsPagingRequest request);

    }
}

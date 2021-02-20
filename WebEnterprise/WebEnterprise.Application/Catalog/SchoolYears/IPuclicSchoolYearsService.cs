using WebEnterprise.ViewModels.Catalog.SchoolYears;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.SchoolYears
{
    public interface IPuclicSchoolYearsService
    {
        PagedResult<SchoolYearsViewModel> GetAllByCategoryId(int schoolyearId, int pageIndex, int pageSize);
    }
}

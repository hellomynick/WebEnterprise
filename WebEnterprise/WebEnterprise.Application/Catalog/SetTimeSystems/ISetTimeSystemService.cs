using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.SetTimeSystems
{
    public interface ISetTimeSystemService
    {
        Task<int> Create(SetTimeSystemCreateRequest request);

        Task<int> Update(SetTimeSystemUpdateRequest request);

        Task<PagedResult<SetTimeSystemVm>> GetAllPaging(SetTimeSystemPagingRequest request);

        Task<int> Delete(int id);

        Task<SetTimeSystemVm> GetById(int id);
    }
}
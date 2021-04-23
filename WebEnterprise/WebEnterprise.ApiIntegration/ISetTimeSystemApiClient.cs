using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.SetTimeSystem;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public interface ISetTimeSystemApiClient
    {
        Task<bool> CreateTime(SetTimeSystemCreateRequest request);

        Task<bool> UpdateTime(SetTimeSystemUpdateRequest request);

        Task<PagedResult<SetTimeSystemVm>> GetAll(SetTimeSystemPagingRequest request);

        Task<SetTimeSystemVm> GetById(int id);

        Task<bool> DeleteTime(int id);
    }
}
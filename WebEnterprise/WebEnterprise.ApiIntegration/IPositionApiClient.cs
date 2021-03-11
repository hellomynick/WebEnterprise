using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Positions;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ApiIntegration
{
    public interface IPositionApiClient
    {
        Task<PagedResult<PositionsVm>> GetPagings(GetPositionsPagingRequest request);

        Task<bool> CreatePosition(PositionsCreateRequest request);

        Task<PositionsVm> GetById(int id);

        Task<bool> UpdatePosition(PositionsUpdateRequest request);

        Task<PagedResult<PositionsVm>> GetByUserID(GetPositionsPagingRequest request);
    }
}
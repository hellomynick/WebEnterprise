using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.ViewModels.Catalog.Positions;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.Application.Catalog.Positions
{
    public interface IPositionsService
    {
        Task<int> Create(PositionsCreateRequest request);

        Task<int> Update(PositionsUpdateRequest request);

        Task<int> Delete(int positionId);

        Task<PagedResult<PositionsVm>> GetAllPaging(GetPositionsPagingRequest request);

        Task<PagedResult<PositionsVm>> GetAllByUserId(GetPositionsPagingRequest request);

        Task<PositionsVm> GetById(int positionId);
    }
}
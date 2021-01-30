using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos.Manage;
using WebEnterprise.Application.Dtos;

namespace WebEnterprise.Application.Catalog.DepartmentCatelogorys
{
    public interface IManageDepartmentCatelogorysService
    {
        Task<int> Create(DepartmentCatelogorysCreateRequest request);
        Task<int> Update(DepartmentCatelogorysUpdateRequest request);
        Task<int> Delete(int departmentId);
        Task<List<DepartmentCatelogorysViewModel>> GetAll();
        Task<PageResult<DepartmentCatelogorysViewModel>> GetAllPaging(DepartmentCatelogorysPagingRequest request);

    }
}

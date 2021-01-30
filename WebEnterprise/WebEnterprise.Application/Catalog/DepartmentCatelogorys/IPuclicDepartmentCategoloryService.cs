using System;
using System.Collections.Generic;
using System.Text;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos.Public;
using WebEnterprise.Application.Dtos;

namespace WebEnterprise.Application.Catalog.DepartmentCatelogorys
{
    public interface IPuclicDepartmentCatelogorysService
    {
        PageResult<DepartmentCatelogorysViewModel> GetAllByCategoryId(GetDepartmentCategoloryPagingRequest request);
    }
}

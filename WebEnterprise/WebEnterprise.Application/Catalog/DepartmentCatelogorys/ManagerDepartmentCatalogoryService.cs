using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos.Manage;
using WebEnterprise.Application.Catalog.DepartmentCatelogorys.Dtos;
using WebEnterprise.Application.Dtos;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Application.Catalog.DepartmentCatelogorys
{
    public class ManagerDepartmentCatelogorysService : IManageDepartmentCatelogorysService
    {
        private readonly WebEnterpriseDbContext _context;
        public ManagerDepartmentCatelogorysService(WebEnterpriseDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DepartmentCatelogorysCreateRequest request)
        {
            var departmentcategolory = new DepartmentCatelogory()
            {
                Name = request.Name,
            };
            _context.DepartmentCatelogories.Add(departmentcategolory);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentCatelogorysViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<DepartmentCatelogorysViewModel>> GetAllPaging(DepartmentCatelogorysPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(DepartmentCatelogorysUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

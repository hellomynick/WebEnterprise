using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebEnterprise.Application.Catalog.Documents.Dtos;
using WebEnterprise.Application.Dtos;
using WebEnterprise.Data.EF;
using WebEnterprise.Data.Entities;

namespace WebEnterprise.Application.Catalog.Documents
{
    public class ManagerDocumentsService : IManageDocumentsService
    {
        private readonly WebEnterpriseDbContext _context;
        public ManagerDocumentsService(WebEnterpriseDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DocumentsCreateRequest request)
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

        public async Task<List<DocumentsViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task<PageResult<DocumentsViewModel>> GetAllPaging(DocumentsPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(DocumentsUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

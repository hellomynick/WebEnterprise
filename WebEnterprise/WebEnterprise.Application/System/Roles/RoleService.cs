using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEnterprise.Data.Entities;
using WebEnterprise.ViewModels.System.Roles;

namespace WebEnterprise.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<GroupUser> _roleManager;

        public RoleService(RoleManager<GroupUser> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();

            return roles;
        }
    }
}
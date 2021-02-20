using System;
using System.Collections.Generic;
using WebEnterprise.ViewModels.Common;

namespace WebEnterprise.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
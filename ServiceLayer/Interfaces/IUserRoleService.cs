using ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserRoleService
    {
        IEnumerable<string> GetRolesOfUser(int userId);

        bool UserHasRole(int userId, string roleName);

        Task AddRoleAsync(UserRole role);

        Task RemoveRoleAsync(int id);
            
    }
}

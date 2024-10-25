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
        Task<IEnumerable<string>> GetRolesOfUserAsync(int userId);

        bool UserHasRole(int userId, string roleName);

        Task AddRoleAsync(UserRole role);

        Task RemoveRoleAsync(int id);

        Task UpdateRolesAsync(int userId, List<int> newRoleIds);

        Task RequestRoleAsync(int userId, int roleId);

        Task AcceptRoleRequestAsync(int userId, int roleId);

        Task<IEnumerable<UserRole>> GetAllPendingRoleRequestsAsync();
    }
}

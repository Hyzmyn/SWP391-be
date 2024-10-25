using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<string>> GetRolesOfUserAsync(int userId)
        {
            return await _unitOfWork.Repository<UserRole>()
                .AsQueryable()
                .AsNoTracking()
                .Where(s => s.UserId == userId)
                .Include(s => s.Role)
                .Select(s => s.Role.Name)
                .ToListAsync();
        }

        public bool UserHasRole(int userId, string roleName)
        {
            return _unitOfWork.Repository<UserRole>()
                .AsQueryable() 
                .Where(s => s.UserId == userId)
                .Include(s => s.Role) 
                .Any(s => s.Role != null && s.Role.Name == roleName); 
        }

        public async Task AddRoleAsync(UserRole role)
        {
            await _unitOfWork.Repository<UserRole>().InsertAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRolesAsync(int userId, List<int> newRoleIds)
        {
            var existingRoles = await _unitOfWork.Repository<UserRole>()
                                                  .GetWhere(ur => ur.UserId == userId);

            // Remove roles that are not in the newRoleIds list
            var rolesToRemove = existingRoles.Where(er => !newRoleIds.Contains(er.RoleId)).ToList();
            foreach (var role in rolesToRemove)
            {
                _unitOfWork.Repository<UserRole>().Delete(role);
            }

            // Add new roles that the user doesn't already have
            var rolesToAdd = newRoleIds.Where(nr => !existingRoles.Any(er => er.RoleId == nr)).ToList();
            foreach (var roleId in rolesToAdd)
            {
                var newRole = new UserRole { UserId = userId, RoleId = roleId };
                await _unitOfWork.Repository<UserRole>().InsertAsync(newRole);
            }

            await _unitOfWork.CommitAsync();  // Save the changes
        }


        public async Task RemoveRoleAsync(int id)
        {
            var role = await _unitOfWork.Repository<UserRole>().GetById(id);
            if (role != null)
            {
                _unitOfWork.Repository<UserRole>().Delete(role);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception($"UserRole with RoleID {id} not found.");
            }
        }
    }
}

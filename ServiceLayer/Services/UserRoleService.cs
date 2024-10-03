using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class UserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<string> GetRolesOfUser(int userId)
        {
            return _unitOfWork.Repository<UserRole>()
                .AsQueryable()
                .Where(s => s.UserId == userId)
                .Include(s => s.Role)
                .Select(s => s.Role.Name)
                .ToList();
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

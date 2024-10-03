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
    public class ShelterStaffService : IShelterStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelterStaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<string> GetStaffsOfSheler(int shelterId)
        {
            return _unitOfWork.Repository<ShelterStaff>()
                .AsQueryable()
                .Where(s => s.ShelterId == shelterId)
                .Include(s => s.User)
                .Select(s => s.User.Username)
                .ToList();
        }

        //public bool StaffHasShelter(int userId, string shelterName)
        //{
        //    return _unitOfWork.Repository<ShelterStaff>()
        //        .AsQueryable()
        //        .Where(s => s.UserId == userId)
        //        .Include(s => s.Shelter)
        //        .Any(s => s.Shelter != null && s.Shelter.Name == shelterName);
        //}

        public async Task AddStaffAsync(ShelterStaff staff)
        {
            await _unitOfWork.Repository<ShelterStaff>().InsertAsync(staff);
            await _unitOfWork.CommitAsync();
        }


        public async Task RemoveStaffAsync(int id)
        {
            var staff = await _unitOfWork.Repository<ShelterStaff>().GetById(id);
            if (staff != null)
            {
                _unitOfWork.Repository<ShelterStaff>().Delete(staff);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception($"UserStaff with StaffID {id} not found.");
            }
        }
    }
}

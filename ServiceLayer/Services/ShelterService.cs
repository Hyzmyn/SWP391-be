﻿using Microsoft.EntityFrameworkCore;
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
    public class ShelterService : IShelterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShelterService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Lấy tất cả các Shelter bao gồm các Pets và Status của từng Pet.
        /// </summary>
        /// <returns>Danh sách các Shelter.</returns>
        public async Task<IEnumerable<Shelter>> GetAllSheltersAsync()
        {
            return await _unitOfWork.Repository<Shelter>()
                .GetAll()
                .Include(s => s.Pets)
                    .ThenInclude(p => p.Statuses)
                        .ThenInclude(ps => ps.Status) // Bao gồm thông tin Status từ PetStatus
                .Include(s => s.Users)
                .Include(s => s.Events)
                .Include(s => s.Donations)
                .ToListAsync();
        }

        /// <summary>
        /// Lấy Shelter theo ID bao gồm các Pets và Status của từng Pet.
        /// </summary>
        /// <param name="shelterId">ID của Shelter.</param>
        /// <returns>Shelter nếu tìm thấy; ngược lại, null.</returns>
        public async Task<Shelter?> GetShelterByIdAsync(int shelterId)
        {
            return await _unitOfWork.Repository<Shelter>()
                .GetAll()
                .Include(s => s.Pets)
                    .ThenInclude(p => p.Statuses)
                        .ThenInclude(ps => ps.Status) // Bao gồm thông tin Status từ PetStatus
                .Include(s => s.Users)
                .Include(s => s.Events)
                .Include(s => s.Donations)
                .FirstOrDefaultAsync(s => s.Id == shelterId);
        }

        /// <summary>
        /// Lấy Shelter liên kết với một User cụ thể nếu User có vai trò "ShelterStaff".
        /// </summary>
        /// <param name="userId">ID của User.</param>
        /// <returns>Shelter nếu tìm thấy và User có quyền truy cập; ngược lại, null.</returns>
        public async Task<Shelter?> GetShelterByUserIdAsync(int userId)
        {
            var user = await _unitOfWork.Repository<User>()
                .GetAll()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            // Kiểm tra xem người dùng có vai trò "ShelterStaff" không
            bool isShelterStaff = user.UserRoles.Any(ur => ur.Role.Name.Equals("ShelterStaff", StringComparison.OrdinalIgnoreCase));

            if (!isShelterStaff || !user.ShelterId.HasValue)
            {
                return null;
            }

            // Lấy Shelter dựa trên ShelterId của người dùng
            return await _unitOfWork.Repository<Shelter>()
                .GetAll()
                .Include(s => s.Pets)
                    .ThenInclude(p => p.Statuses)
                        .ThenInclude(ps => ps.Status) // Bao gồm thông tin Status từ PetStatus
                .Include(s => s.Users)
                .Include(s => s.Events)
                .Include(s => s.Donations)
                .FirstOrDefaultAsync(s => s.Id == user.ShelterId.Value);
        }

        /// <summary>
        /// Tạo một Shelter mới.
        /// </summary>
        /// <param name="shelter">Thông tin Shelter mới.</param>
        /// <returns>Shelter đã được tạo.</returns>
        public async Task<Shelter> CreateShelterAsync(Shelter shelter)
        {
            if (shelter == null)
            {
                throw new ArgumentNullException(nameof(shelter));
            }

            await _unitOfWork.Repository<Shelter>().InsertAsync(shelter);
            await _unitOfWork.CommitAsync();
            return shelter;
        }

        /// <summary>
        /// Cập nhật thông tin của một Shelter.
        /// </summary>
        /// <param name="shelter">Thông tin Shelter cần cập nhật.</param>
        /// <returns>Shelter đã được cập nhật.</returns>
        public async Task<Shelter> UpdateShelterAsync(Shelter shelter)
        {
            if (shelter == null)
            {
                throw new ArgumentNullException(nameof(shelter));
            }

            var existingShelter = await _unitOfWork.Repository<Shelter>().GetById(shelter.Id);
            if (existingShelter == null)
            {
                throw new KeyNotFoundException($"Shelter with ID {shelter.Id} not found.");
            }

            // Cập nhật các thuộc tính cần thiết
            existingShelter.Name = shelter.Name;
            existingShelter.Location = shelter.Location;
            existingShelter.PhoneNumber = shelter.PhoneNumber;
            existingShelter.Capaxity = shelter.Capaxity;
            existingShelter.Email = shelter.Email;
            existingShelter.Website = shelter.Website;
            existingShelter.DonationAmount = shelter.DonationAmount;

            _unitOfWork.Repository<Shelter>().Update(existingShelter, existingShelter.Id);
            await _unitOfWork.CommitAsync();

            return existingShelter;
        }

        /// <summary>
        /// Xóa một Shelter theo ID.
        /// </summary>
        /// <param name="shelterId">ID của Shelter cần xóa.</param>
        /// <returns>True nếu xóa thành công; ngược lại, false.</returns>
        public async Task<bool> DeleteShelterAsync(int shelterId)
        {
            var shelter = await _unitOfWork.Repository<Shelter>().GetById(shelterId);
            if (shelter == null)
            {
                return false;
            }

            _unitOfWork.Repository<Shelter>().Delete(shelter);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}

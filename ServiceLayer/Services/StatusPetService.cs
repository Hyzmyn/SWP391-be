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
    public class StatusPetService : IStatusPetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusPetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tạo mới Status
        public async Task CreateStatusAsync(Status status)
        {
            await _unitOfWork.Repository<Status>().InsertAsync(status);
            await _unitOfWork.CommitAsync();
        }

        // Lấy thông tin tất cả Status của một Pet
        public IEnumerable<Status> GetStatusesForPet(int petId)
        {
            return _unitOfWork.Repository<Status>()
                .AsQueryable()
                .Include(s => s.Pet)
                .Where(s => s.Pet != null && s.Pet.Id == petId)
                .ToList();
        }

        // Lấy Status theo ID
        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Status>()
                .AsQueryable()
                .Include(s => s.Pet) 
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Cập nhật thông tin Status
        public async Task UpdateStatusAsync(Status status)
        {
            var existingStatus = await _unitOfWork.Repository<Status>().GetById(status.Id);
            if (existingStatus != null)
            {
                existingStatus.Name = status.Name;
                existingStatus.Date = status.Date;
                existingStatus.Disease = status.Disease;
                existingStatus.Vaccine = status.Vaccine;
                existingStatus.PetId = status.PetId;

                await _unitOfWork.Repository<Status>().Update(existingStatus, status.Id);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception("Status not found");
            }
        }

        // Xóa Status
        public async Task DeleteStatusAsync(int id)
        {
            var status = await _unitOfWork.Repository<Status>().GetById(id);
            if (status != null)
            {
                _unitOfWork.Repository<Status>().Delete(status);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new Exception($"Status with ID {id} not found.");
            }
        }
    }

}

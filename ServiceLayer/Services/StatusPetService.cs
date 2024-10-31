using Microsoft.EntityFrameworkCore;
using ModelLayer.Entities;
using RepositoryLayer.UnitOfWork;
using ServiceLayer.Interfaces;
using ServiceLayer.RequestModels;
using ServiceLayer.ResponseModels;
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


        // lấy tất cả Status
        public async Task<IEnumerable<StatusResponseModel>> GetAllStatusAsync()
        {
            var statusRepository = _unitOfWork.Repository<Status>();
            var petStatusRepository = _unitOfWork.Repository<PetStatus>();

            // Lọc các Status không có PetId trong bảng PetStatus và xóa chúng
            var orphanStatuses = await statusRepository
                .AsQueryable()
                .Where(status => !petStatusRepository
                    .AsQueryable()
                    .Any(ps => ps.StatusId == status.Id))
                .ToListAsync();

            foreach (var orphanStatus in orphanStatuses)
            {
                statusRepository.Delete(orphanStatus);
            }

            if (orphanStatuses.Any())
            {
                await _unitOfWork.CommitAsync();
            }

            // Lấy các Status có PetId và trả về
            var statuses = await statusRepository
                .AsQueryable()
                .Where(status => petStatusRepository
                    .AsQueryable()
                    .Any(ps => ps.StatusId == status.Id))
                .ToListAsync();

            var statusResponses = statuses.Select(status => new StatusResponseModel
            {
                StatusId = status.Id,
                Date = status.Date,
                Disease = status.Disease,
                Vaccine = status.Vaccine
            });

            return statusResponses;
        }


        // Lấy tất cả các Status cho một Pet cụ thể
        public async Task<IEnumerable<StatusResponseModel>> GetStatusesForPetAsync(int petId)
        {
            var statuses = await _unitOfWork.Repository<PetStatus>()
                .AsQueryable()
                .Where(ps => ps.PetId == petId)
                .Include(ps => ps.Status)
                .Select(ps => ps.Status)
                .ToListAsync();

            var statusResponses = statuses.Select(status => new StatusResponseModel
            {
                StatusId = status.Id,
                Date = status.Date,
                Disease = status.Disease,
                Vaccine = status.Vaccine
            });

            return statusResponses;
        }

        // Lấy Status theo ID
        public async Task<StatusResponseModel> GetStatusByIdAsync(int id)
        {
            var statusRepository = _unitOfWork.Repository<Status>();
            var petStatusRepository = _unitOfWork.Repository<PetStatus>();

            // Kiểm tra nếu Status không có PetId
            var hasPetId = await petStatusRepository
                .AsQueryable()
                .AnyAsync(ps => ps.StatusId == id);

            if (!hasPetId)
            {
                var orphanStatus = await statusRepository
                    .AsQueryable()
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (orphanStatus != null)
                {
                    statusRepository.Delete(orphanStatus);
                    await _unitOfWork.CommitAsync();
                }

                throw new Exception("Status đã bị delete do không có PetId.");
            }

            // Nếu có PetId, trả về thông tin Status
            var status = await statusRepository
                .AsQueryable()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (status == null)
                throw new Exception($"Không tìm thấy Status với ID {id}.");

            var statusResponse = new StatusResponseModel
            {
                StatusId = status.Id,
                Date = status.Date,
                Disease = status.Disease,
                Vaccine = status.Vaccine
            };

            return statusResponse;
        }

        // Tạo mới Status
        public async Task<StatusResponseModel> CreateStatusAsync(StatusCreateRequest createStatusRequest)
        {
            var vietnamTime = createStatusRequest.Date.ToOffset(TimeSpan.FromHours(7)).DateTime;

            var status = new Status
            {
                Date = vietnamTime,  
                Disease = createStatusRequest.Disease,
                Vaccine = createStatusRequest.Vaccine
            };

            await _unitOfWork.Repository<Status>().InsertAsync(status);
            await _unitOfWork.CommitAsync();

            // Liên kết Status với Pet nếu cần
            var petStatus = new PetStatus
            {
                PetId = createStatusRequest.PetId,
                StatusId = status.Id
            };

            await _unitOfWork.Repository<PetStatus>().InsertAsync(petStatus);
            await _unitOfWork.CommitAsync();

            var statusResponse = new StatusResponseModel
            {
                StatusId = status.Id,
                Date = status.Date,
                Disease = status.Disease,
                Vaccine = status.Vaccine
            };

            return statusResponse;
        }

        // Cập nhật Status
        public async Task<StatusResponseModel> UpdateStatusAsync(int id, StatusUpdateRequestModel updateStatusRequest)
        {
            var existingStatus = await _unitOfWork.Repository<Status>().GetById(id);
            if (existingStatus == null)
                throw new Exception($"Không tìm thấy Status với ID {id}.");

            var vietnamTime = updateStatusRequest.Date.ToOffset(TimeSpan.FromHours(7)).DateTime;

            // Cập nhật các thuộc tính
            existingStatus.Date = vietnamTime; 
            existingStatus.Disease = updateStatusRequest.Disease;
            existingStatus.Vaccine = updateStatusRequest.Vaccine;

            _unitOfWork.Repository<Status>().Update(existingStatus, id);
            await _unitOfWork.CommitAsync();

            var statusResponse = new StatusResponseModel
            {
                StatusId = existingStatus.Id,
                Date = existingStatus.Date,
                Disease = existingStatus.Disease,
                Vaccine = existingStatus.Vaccine
            };

            return statusResponse;
        }


        // Xóa Status
        public async Task<bool> DeleteStatusAsync(int id)
        {
            var status = await _unitOfWork.Repository<Status>().GetById(id);
            if (status == null)
                throw new Exception($"Không tìm thấy Status với ID {id}.");

            _unitOfWork.Repository<Status>().Delete(status);
            await _unitOfWork.CommitAsync();

            return true;
        }
    }

}
